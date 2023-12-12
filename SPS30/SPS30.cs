using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS30
{
	public delegate void ReceiveDataEventHandler(object sender, EventArgs e);
	public class SPS30Object
	{
		public int SPS30_MAX_CHARS_TO_PROCESS_ON_ONE_SLICE = 10;

		const int SPS30_MAX_BUFFER_SIZE = 256;
		const byte SPS30_STARTEND_BIT = 0x7E;
		const byte SPS30_START = 0x0; //Start Measuremen
		const byte SPS30_STOP = 0x1;    //Stop Measurement
		const byte SPS30_READ = 0x3;    //Read Measured Value
		const byte SPS30_SLEEP = 0x10;  //Sleep
		const byte SPS30_WAKEUP = 0x11;
		const byte SPS30_STARTFAN = 0x56;
		const byte SPS30_AUTO_RW = 0x80;  //Read/write auto cleaning interval
		const byte SPS30_DEVINFO = 0xD0;  //Device information
		const byte SPS30_VERSION = 0xD1;  //Read version
		const byte SPS30_STATUS = 0xD2;  //Read device status register
		const byte SPS30_RESET = 0xD3;  //Reset

		Controls.SerialComObject serialComObject = new Controls.SerialComObject();
		public bool IsOpen { get { return serialComObject.IsOpen; } }
		
        public string device_info { get; set; }
		public SPS30_VERSION version = new SPS30_VERSION();
		public byte[] sps30_tx_buffer = new byte[SPS30_MAX_BUFFER_SIZE];
		public byte sps30_tx_count = 0;
		public byte[] sps30_rx_buffer = new byte[SPS30_MAX_BUFFER_SIZE];
		public byte sps30_rx_count = 0;
		public SPS30_DATA_INFO sps30_dataInfo = new SPS30_DATA_INFO();
		public Timer timerProcessRx = null;
		public SPS30_STATUS Status = SPS30.SPS30_STATUS.SPS30_STATUS_IDLE;
		public event ReceiveDataEventHandler onReceiveDataEvent;
		public SPS30Object()
        {
			timerProcessRx = new System.Threading.Timer(timerProcessRxCallback, null, 0, 10);
		}
		public void Open(string portname, int baudRate)
        {
			string errormsg = "";
			if(serialComObject.Open(portname, baudRate, out errormsg))
            {
				Thread.Sleep(1000);
				sps30_send_dev_info();
			}
        }
		public void Close()
        {
			serialComObject.Close();
        }
		public void Write(byte[] data, int offset, int length)
        {
			serialComObject.Write(data, offset, length);
        }
		int sps30_make_tx_package(byte cmd, byte[] data, byte data_size)
		{
			byte size = 3;
			sps30_tx_buffer[1] = 0x0; //Address
			sps30_tx_buffer[2] = cmd; //Command
			sps30_tx_buffer[3] = (byte)data_size; //data Length byte
			for (int i = 0; i < data_size; i++)
				sps30_tx_buffer[4 + i] = data[i];
			size += data_size;
			sps30_tx_buffer[size + 1] = sps30_make_checksum(sps30_tx_buffer, 1, size);
			size += 2;
			sps30_tx_buffer[0] = SPS30_STARTEND_BIT;
			sps30_tx_buffer[size] = SPS30_STARTEND_BIT;
			size += 1;
			return size;
		}
		byte sps30_make_checksum(byte[] data, byte first, byte last)
		{
			byte i;
			byte ret = 0;

			for (i = first; i <= last; i++) ret += data[i];
			return (byte)~(ret & 0xff);
		}

		public void sps30_reset()
		{
			if (!serialComObject.IsOpen) return;
			int size = sps30_make_tx_package(SPS30_RESET, null, 0);
			serialComObject.Write(sps30_tx_buffer, 0, size);
		}
		public void sps30_start()
		{
			if (!serialComObject.IsOpen) return;
			int size = sps30_make_tx_package(SPS30_START, new byte[2] { 0x1, 0x3}, 2);
			serialComObject.Write(sps30_tx_buffer, 0, size);
		}
		public void sps30_stop()
		{
			if (!serialComObject.IsOpen) return;
			int size = sps30_make_tx_package(SPS30_STOP, null, 0);
			serialComObject.Write(sps30_tx_buffer, 0, size);
		}
		public void sps30_fan_clean()
		{
			if (!serialComObject.IsOpen) return;
			int size = sps30_make_tx_package(SPS30_STARTFAN, null, 0);
			serialComObject.Write(sps30_tx_buffer, 0, size);
		}
		public void sps30_read()
		{
			if (!serialComObject.IsOpen) return;
			int size = sps30_make_tx_package(SPS30_READ, null, 0);
			serialComObject.Write(sps30_tx_buffer, 0, size);
		}

		public void sps30_send_dev_info()
        {
			if (!serialComObject.IsOpen) return;
			int size = sps30_make_tx_package(SPS30_VERSION, null, 0);
			serialComObject.Write(sps30_tx_buffer, 0, size);
		}
		bool sps30_valid_checksum(byte[] data, int size)
		{
			if (size < 4) return false;
			if (data[0] != SPS30_STARTEND_BIT || data[size - 1] != SPS30_STARTEND_BIT) return false;
			byte checksum = data[size - 2];
			byte calcSum = sps30_make_checksum(data, (byte)1, (byte)(size - 3)); // first, last. checksum
			if (calcSum != checksum) return false;
			return true;
		}

		bool sps30_parse_dev_info(byte[] rxdata, int size)
        {
			byte len = rxdata[4];
			if (len != 0x09 || size < len)
			{
				device_info = "Invalid device information";
				return false; //read data's length must be 9bytes (0x09)
			}
			for(int i = 0; i < len; i ++)
            {
				device_info += rxdata[i + 5];
            }
			return true;
        }
		bool sps30_parse_version(byte[] rxdata, int size)
        {
			byte len = rxdata[4];
			if (len != 0x07 || size < len)
			{
				device_info = "Invalid version";
				return false; //read data's length must be 7bytes (0x07)
			}

			// 7th and 9th bytes are always 0
			version.firmware_major = rxdata[5];
			version.firmware_minor = rxdata[6];
			version.hardware_revision = rxdata[8];
			version.shdlc_major = rxdata[10];
			version.shdlc_minor = rxdata[11];
			return true;
        }
		bool sps30_parse_read_measure_value(byte[] rxdata, int size)
		{
			byte len = rxdata[4];
			if (len != 0x28 || size < len) return false; //read data's length must be 40bytes (0x28)
			byte[] buf = new byte[4];
			int idx = 0;
			for (byte i = 5; i < size - 2; i += 4) // start posistion of real data is 5.
			{
				//that is because of big endian

				buf[3] = rxdata[i];
				buf[2] = rxdata[i + 1];
				buf[1] = rxdata[i + 2];
				buf[0] = rxdata[i + 3];

				float value = System.BitConverter.ToSingle(buf, 0);
				switch (idx)
				{
					case 0: sps30_dataInfo.MassPM10 = value; break;
					case 1: sps30_dataInfo.MassPM25 = value; break;
					case 2: sps30_dataInfo.MassPM40 = value; break;
					case 3: sps30_dataInfo.MassPM100 = value; break;
					case 4: sps30_dataInfo.NumberOfConnectionPM05 = value; break;
					case 5: sps30_dataInfo.NumberOfConnectionPM10 = value; break;
					case 6: sps30_dataInfo.NumberOfConnectionPM25 = value; break;
					case 7: sps30_dataInfo.NumberOfConnectionPM40 = value; break;
					case 8: sps30_dataInfo.NumberOfConnectionPM100 = value; break;
					case 9: sps30_dataInfo.TypicalParticleSize = value; break;
				}
				idx++;
			}
			return true;
		}

		bool sps30_parse_incomming_data(byte[] data, int size)
		{
			if (!sps30_valid_checksum(data, size)) return false; // do nothing if checksum is invalid
			Console.WriteLine("Recevied data: " + size);
			byte cmd = data[2];
			switch (cmd)
			{
				case SPS30_RESET:
					Status = SPS30.SPS30_STATUS.SPS30_STATUS_RESETED;
					break;
				case SPS30_START:
					Status = SPS30.SPS30_STATUS.SPS30_STATUS_STARTED;
					break;
				case SPS30_STOP:
					Status = SPS30.SPS30_STATUS.SPS30_STATUS_STOPED;
					break;
				case SPS30_READ:
					sps30_parse_read_measure_value(data, size);
					break;
				case SPS30_DEVINFO:
					sps30_parse_dev_info(data, size);
					break;
				case SPS30_VERSION:
					sps30_parse_version(data, size);
					break;
			}
			onReceiveDataEvent?.Invoke(this, EventArgs.Empty);
			return true;
		}
		
		private bool byte_stuff = false;
		public void timerProcessRxCallback(object state)
        {
			byte RxChar;
			if (!serialComObject.IsOpen) return;
			for (int i = 0; i < SPS30_MAX_CHARS_TO_PROCESS_ON_ONE_SLICE; i++)
            {
				if (serialComObject.RxBuffer.Head == serialComObject.RxBuffer.Tail) break;

				//must be != because it is circular que.... can not simpley be less than
				RxChar = serialComObject.RxBuffer.buffer[serialComObject.RxBuffer.Tail];
				serialComObject.RxBuffer.Tail++; //point to the next character
				serialComObject.RxBuffer.Tail &= (Controls.ComBuffer.MAX_RX_BUFFER -1); // serialComObject.RxBuffer.Buffer_Size; //circular que with even hex size....
				switch(RxChar)
                {
					case 0x7E: //start and last bit
						if (sps30_rx_count > 4) //unless that musb be longer that 4
						{
							// received data is full.
							sps30_rx_buffer[sps30_rx_count] = RxChar;
							sps30_rx_count++;

							if (sps30_parse_incomming_data(sps30_rx_buffer, sps30_rx_count))
							{
								sps30_rx_count = 0; // reset the buffer point
							}
							else
							{
								//reset the buffer because crc is wrong.
								if (sps30_rx_buffer[sps30_rx_count - 1] == SPS30_STARTEND_BIT) sps30_rx_count = 0; // reset the buffer point
							}
						}
						else // that mean the that is start of data.
						{
							sps30_rx_count = 0;
							sps30_rx_buffer[sps30_rx_count] = RxChar;
							sps30_rx_count++;
						}
						byte_stuff = false;
						break;
					case 0x7D: //that is stuffing byte
						byte_stuff = true;
						break;
					default:
						if (byte_stuff)
						{
							// it need to convert for these bytes. this called byte stuffing
							switch (RxChar)
							{
								case 0x31: RxChar = 0x11; break;
								case 0x33: RxChar = 0x13; break;
								case 0x5d: RxChar = 0x7d; break;
								case 0x5e: RxChar = 0x7e; break;
							}
						}
						sps30_rx_buffer[sps30_rx_count] = RxChar;
						sps30_rx_count++;
						if ((int)sps30_rx_count >= SPS30_MAX_BUFFER_SIZE) //if count is bigger that max buffer size, reset the counter.
							sps30_rx_count = 0;

						byte_stuff = false;
						break;
                }
			}
		}
	}


	public class SPS30_DATA_INFO
	{
		public float MassPM10; //Mass Concentration PM1.0 [µg/m³]
		public float MassPM25;  //Mass Concentration PM2.5 [µg/m³]
		public float MassPM40; //Mass Concentration PM4.0 [µg/m³]
		public float MassPM100; // Mass Concentration PM10 [µg/m³]
		public float NumberOfConnectionPM05; // Number Concentration PM0.5 [#/cm³]
		public float NumberOfConnectionPM10; // Number Concentration PM1.0 [#/cm³]
		public float NumberOfConnectionPM25; // Number Concentration PM2.5 [#/cm³]
		public float NumberOfConnectionPM40; // Number Concentration PM4.0 [#/cm³]
		public float NumberOfConnectionPM100; //Number Concentration PM10 [#/cm³]
		public float TypicalParticleSize;  // Typical Particle Size8 [µm]
	}

	public enum SPS30_STATUS
	{
		SPS30_STATUS_IDLE= 0x0,
		SPS30_STATUS_RESETED = 0x1,
		SPS30_STATUS_STARTED = 0x2,
		SPS30_STATUS_STOPED = 0x3,
	};
	public class SPS30_VERSION
    {
		public byte firmware_major;
		public byte firmware_minor;
		public byte hardware_revision;
		public byte shdlc_major;
		public byte shdlc_minor;
		public override string ToString()
        {
			return $"Firmware: v{firmware_major}.{firmware_minor}, Hardware: v{hardware_revision}, SHDLC: v{shdlc_major}.{shdlc_minor}";
        }
	}
}
