using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controls
{
    public enum SERIALTYPE
    {
        SIMPLE, SECS, SPS30
    }
    public class SerialComObject : IDisposable
    {
        public static int MAX_CHARS_TO_READ_ON_ONE_SLICE = 10;
        public static int MAX_BUFFER_SIZE = 4096;

        public int SimpleMessageWaiting = 0;

        public SerialPort serialPort = new SerialPort();
        bool IsDisposed = false;
        public string ReceivedString { get; private set; }
        public bool IsOpen { get { return serialPort.IsOpen; } }
        public delegate void SecsMessageReceivedDelegate(byte[] data, int dataSize);

        public delegate void SimpleDelegate();

        public byte[] ReceiveRawData = new byte[MAX_BUFFER_SIZE];
        public int ReceiveRawDataSize = 0;
        public Timer timerRxMsg = null;
        public Timer timerTxMsg = null;

        public ComBuffer RxBuffer = new ComBuffer();
        public ComBuffer TxBuffer = new ComBuffer();

        public int LastCharacterRecieved = 0;

        public int LastCharacterRead = 0;
        private BackgroundWorker backWorker = new BackgroundWorker();
        public SerialComObject()
        {
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;

            timerRxMsg = new System.Threading.Timer(timerRawDataRxCallback, null, 0, 10);
            timerTxMsg = new System.Threading.Timer(timerRawDataTxCallback, null, 0, 1);
        }
      
        public void timerRawDataRxCallback(object state)
        {
            try
            {
                if (!serialPort.IsOpen) return;//port is closed so leave
                for(int i = 0; i < MAX_CHARS_TO_READ_ON_ONE_SLICE; i++)
                {
                    if (serialPort.BytesToRead == 0) break;
                    byte rawByte = (byte)serialPort.ReadByte();
                    RxBuffer.buffer[RxBuffer.Head] = rawByte;
                    RxBuffer.Head++;
                    RxBuffer.Head &= (ComBuffer.MAX_RX_BUFFER -1);
                    Console.WriteLine("aaaaaaaaaaaa" + RxBuffer.Head);
                }
            }
            catch (Exception ex)
            {
                //report error
            }
        }
        public void timerRawDataTxCallback(object state)
        {
            try
            {
                if (!serialPort.IsOpen) return;//port is closed so leave
                for (int i = 0; i < MAX_CHARS_TO_READ_ON_ONE_SLICE; i++)
                {
                    if (TxBuffer.Head == TxBuffer.Tail) break;
                    serialPort.Write(new byte[] { TxBuffer.buffer[TxBuffer.Tail] }, 0, 1);
                    TxBuffer.Tail++;
                    TxBuffer.Tail &= (ComBuffer.MAX_RX_BUFFER -1);
                    
                }                   
            }
            catch (Exception ex)
            {
                //report error
            }

        }

        //public virtual void timerMessageProcessorCallback(object state){ }

        public void Dispose()
        {
            IsDisposed = true;
            if (serialPort.IsOpen)
                serialPort.Close();

            serialPort.Dispose();
        }

        public void Close()
        {
            serialPort.Close();
        }
        public bool Open(string port, int baud, out string errormsg)
        {
            errormsg = "";
            bool result = false;
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.PortName = port;
                serialPort.BaudRate = baud;
                serialPort.Open();
                IsDisposed = false;
                result = true;
                errormsg = $"Connected to Port {port} with  Baud speed {baud} .";
            }
            catch (UnauthorizedAccessException ex)
            {
                errormsg = $"Error: Port {port} is in use";
                result = false;
            }
            catch (Exception e)
            {
                errormsg = "Uart exception: " + e;
                result = false;
            }
            return result;
        }

        public bool Write(byte[] data, int offset, int length)
        {
            if (serialPort.IsOpen)
            {
                //serialPort.Write(data, offset, length);
                for (int i = offset; i < length; i ++)
                    TxBuffer.AddByteToBuffer(data[i]);
                return true;
            }
            return false;
        }
        public bool Write(byte bt)
        {
            byte[] b = new byte[1];
            b[0] = bt;
            return Write(b, 0, 1);
        }
        public bool Write(string data)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(data);
                return true;
            }
            return false;
        }
    }

    public class ComBuffer
    {
        public const int MAX_RX_BUFFER = 1024;
        public byte[] buffer = new byte[MAX_RX_BUFFER];
        public int Head = 0;
        public int Tail = 0;
        public void AddByteToBuffer(byte rawByte)
        {
            buffer[Head] = rawByte;
            Head++;
            Head &= (MAX_RX_BUFFER-1);
        }
    }
}
