using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPS30
{
    public partial class MainForm : Form
    {
        SPS30Object sps30Object = new SPS30Object();
        byte[] serialTxBuffer = new byte[4096];
        byte SendCounter = 0;
        public MainForm()
        {
            InitializeComponent();
            this.Text = $"{RevisionHistory.RevisionHeader} {RevisionHistory.MajorStep}.{RevisionHistory.MinorStep} - {RevisionHistory.RevisionDate}";
            string[] ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                cmbSerialPorts.Items.Add(port.ToString());
            }
            cmbBaudRate.SelectedIndex = 0;
            cmbBytes.SelectedIndex = 1;
            sps30Object.onReceiveDataEvent += Sps30Object_onReceiveDataEvent;
        }

        private void Sps30Object_onReceiveDataEvent(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    WriteLog(sps30Object.sps30_rx_buffer, sps30Object.sps30_rx_count);
                    if(chkFormat.Checked)
                    {
                        WriteLogParsedData(sps30Object.sps30_rx_buffer, sps30Object.sps30_rx_count);
                    }
                    UpdateSPS30Data();
                });
            }
            else
            {
                WriteLog(sps30Object.sps30_rx_buffer, sps30Object.sps30_rx_count);
                if (chkFormat.Checked)
                {
                    WriteLogParsedData(sps30Object.sps30_rx_buffer, sps30Object.sps30_rx_count);
                }
                UpdateSPS30Data();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (sps30Object.IsOpen)
                {
                    sps30Object.Close();
                }
                else
                {
                    sps30Object.Open(cmbSerialPorts.Text, int.Parse(cmbBaudRate.Text));
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            
            btnConnect.Text = sps30Object.IsOpen ? "Disconnect" : "Connect";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            sps30Object.sps30_reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (chkLoop.Checked)
            {
                sps30Object.sps30_read();
            }
            if(sps30Object.IsOpen)
            {
                
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            sps30Object.sps30_start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sps30Object.sps30_stop();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            sps30Object.sps30_read();
        }
    
        private void chkLoop_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void UpdateSPS30Data()
        {
            lblRevision.Text = sps30Object.version.ToString();

            lblStatus.Text = sps30Object.Status.ToString();
            lblPM10.Text = sps30Object.sps30_dataInfo.MassPM10.ToString("0.###");
            lblPM25.Text = sps30Object.sps30_dataInfo.MassPM25.ToString("0.###");
            lblPM40.Text = sps30Object.sps30_dataInfo.MassPM40.ToString("0.###");
            lblPM100.Text = sps30Object.sps30_dataInfo.MassPM100.ToString("0.###");
            lblNPM05.Text = sps30Object.sps30_dataInfo.NumberOfConnectionPM05.ToString("0.###");
            lblNPM10.Text = sps30Object.sps30_dataInfo.NumberOfConnectionPM10.ToString("0.###");
            lblNPM25.Text = sps30Object.sps30_dataInfo.NumberOfConnectionPM25.ToString("0.###");
            lblNPM40.Text = sps30Object.sps30_dataInfo.NumberOfConnectionPM40.ToString("0.###");
            lblNPM100.Text = sps30Object.sps30_dataInfo.NumberOfConnectionPM100.ToString("0.###");
            lblTPSize.Text = sps30Object.sps30_dataInfo.TypicalParticleSize.ToString("0.###");
            this.Invalidate();
        }
        private void WriteLog(byte[] data, byte size)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < size; i++)
            {
                if (i != 0 && i % 16 == 0) sb.AppendLine();
                sb.Append($"{data[i].ToString("X2")} ");
            }
            sb.AppendLine();
            richTextBox1.AppendText(sb.ToString());
        }

        private void btnFanClean_Click(object sender, EventArgs e)
        {
            sps30Object.sps30_fan_clean();
        }

        private void btnSendBuffer_Click(object sender, EventArgs e)
        {
            if (!sps30Object.IsOpen) return;
            int bytes = int.Parse(cmbBytes.Text);
            byte sum = 0;

            for(int i = 0; i < bytes-3; i ++)
            {
                if(i == 1)
                {
                    serialTxBuffer[i + 1] = SendCounter;
                } else if(i == 2)
                {
                    serialTxBuffer[i + 1] = (byte)(bytes- 2); //all byte size without start and last bit
                }
                else
                {
                    serialTxBuffer[i + 1] = 1;
                }
                
                sum += (byte)serialTxBuffer[i + 1];
            }
            byte checksum = (byte)~(sum & 0xff);
            richTextBox1.AppendText($"\nCHECKSUM: 0x{checksum.ToString("X2")}\n");


            serialTxBuffer[bytes - 2] = checksum;
            serialTxBuffer[0] = 0x7E;
            serialTxBuffer[bytes-1] = 0x7E;
            sps30Object.Write(serialTxBuffer, 0, bytes);
            SendCounter++;
        }

        private void btnGetRevision_Click(object sender, EventArgs e)
        {
            sps30Object.sps30_send_dev_info();
        }
        private void WriteLogParsedData(byte[] rxdata, int size)
        {
            // this is for only Read data
            if (rxdata[2] != 0x03) return;
            byte len = rxdata[4];
            StringBuilder sb = new StringBuilder();

            if (len != 0x28 || size < len) return; //read data's length must be 40bytes (0x28)
            
            byte[] buf = new byte[4];
            int idx = 0;
            sb.AppendLine("Processed=");
            for (byte i = 5; i < size - 2; i += 4) // start posistion of real data is 5.
            {
                //that is because of big endian

                buf[3] = rxdata[i];
                buf[2] = rxdata[i + 1];
                buf[1] = rxdata[i + 2];
                buf[0] = rxdata[i + 3];
                float value = System.BitConverter.ToSingle(buf, 0);
                sb.Append($"{rxdata[i].ToString("X2")} {rxdata[i + 1].ToString("X2")} {rxdata[i + 2].ToString("X2")} {rxdata[i + 3].ToString("X2")}->");
                sb.Append($"{buf[0].ToString("X2")} {buf[01].ToString("X2")} {buf[2].ToString("X2")} {buf[3].ToString("X2")}->");
                sb.Append($"{value.ToString("0.###")}\n");
                idx++;
            }
            sb.AppendLine();
            richTextBox1.AppendText(sb.ToString());
        }

        private void chkFormat_CheckedChanged(object sender, EventArgs e)
        {
            chkFormat.Text = chkFormat.Checked ? "FORMAT" : "HEX";
        }
    }
}
