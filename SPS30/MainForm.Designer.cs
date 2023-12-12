
namespace SPS30
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblPM10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPM25 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPM40 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPM100 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNPM10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNPM25 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblNPM40 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblNPM05 = new System.Windows.Forms.Label();
            this.lblNPM100 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTPSize = new System.Windows.Forms.Label();
            this.btnFanClean = new System.Windows.Forms.Button();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnSendBuffer = new System.Windows.Forms.Button();
            this.cmbBytes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGetRevision = new System.Windows.Forms.Button();
            this.chkFormat = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(26, 12);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(121, 30);
            this.cmbSerialPorts.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(306, 14);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 26);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(26, 177);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(410, 424);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(460, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(460, 147);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(117, 26);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(583, 147);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(131, 26);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(460, 188);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(117, 26);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(583, 190);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(114, 26);
            this.chkLoop.TabIndex = 3;
            this.chkLoop.Text = "1ms Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            this.chkLoop.CheckedChanged += new System.EventHandler(this.chkLoop_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mass Concentration PM1.0 [µg/m³]";
            // 
            // lblPM10
            // 
            this.lblPM10.AutoSize = true;
            this.lblPM10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPM10.Location = new System.Drawing.Point(753, 216);
            this.lblPM10.Name = "lblPM10";
            this.lblPM10.Size = new System.Drawing.Size(103, 32);
            this.lblPM10.TabIndex = 5;
            this.lblPM10.Text = "###.##";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mass Concentration PM2.5 [µg/m³]";
            // 
            // lblPM25
            // 
            this.lblPM25.AutoSize = true;
            this.lblPM25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPM25.Location = new System.Drawing.Point(753, 253);
            this.lblPM25.Name = "lblPM25";
            this.lblPM25.Size = new System.Drawing.Size(103, 32);
            this.lblPM25.TabIndex = 5;
            this.lblPM25.Text = "###.##";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mass Concentration PM4.0 [µg/m³]";
            // 
            // lblPM40
            // 
            this.lblPM40.AutoSize = true;
            this.lblPM40.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPM40.Location = new System.Drawing.Point(753, 290);
            this.lblPM40.Name = "lblPM40";
            this.lblPM40.Size = new System.Drawing.Size(103, 32);
            this.lblPM40.TabIndex = 5;
            this.lblPM40.Text = "###.##";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = "Mass Concentration PM10 [µg/m³]";
            // 
            // lblPM100
            // 
            this.lblPM100.AutoSize = true;
            this.lblPM100.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPM100.Location = new System.Drawing.Point(753, 327);
            this.lblPM100.Name = "lblPM100";
            this.lblPM100.Size = new System.Drawing.Size(103, 32);
            this.lblPM100.TabIndex = 5;
            this.lblPM100.Text = "###.##";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(463, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 22);
            this.label9.TabIndex = 4;
            this.label9.Text = "Number Concentration PM0.5 [#/cm³]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(463, 413);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(305, 22);
            this.label11.TabIndex = 4;
            this.label11.Text = "Number Concentration PM1.0 [#/cm³]";
            // 
            // lblNPM10
            // 
            this.lblNPM10.AutoSize = true;
            this.lblNPM10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPM10.Location = new System.Drawing.Point(753, 401);
            this.lblNPM10.Name = "lblNPM10";
            this.lblNPM10.Size = new System.Drawing.Size(103, 32);
            this.lblNPM10.TabIndex = 5;
            this.lblNPM10.Text = "###.##";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(463, 450);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(305, 22);
            this.label13.TabIndex = 4;
            this.label13.Text = "Number Concentration PM2.5 [#/cm³]";
            // 
            // lblNPM25
            // 
            this.lblNPM25.AutoSize = true;
            this.lblNPM25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPM25.Location = new System.Drawing.Point(753, 438);
            this.lblNPM25.Name = "lblNPM25";
            this.lblNPM25.Size = new System.Drawing.Size(103, 32);
            this.lblNPM25.TabIndex = 5;
            this.lblNPM25.Text = "###.##";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(463, 487);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(305, 22);
            this.label15.TabIndex = 4;
            this.label15.Text = "Number Concentration PM4.0 [#/cm³]";
            // 
            // lblNPM40
            // 
            this.lblNPM40.AutoSize = true;
            this.lblNPM40.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPM40.Location = new System.Drawing.Point(753, 475);
            this.lblNPM40.Name = "lblNPM40";
            this.lblNPM40.Size = new System.Drawing.Size(103, 32);
            this.lblNPM40.TabIndex = 5;
            this.lblNPM40.Text = "###.##";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(463, 524);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(300, 22);
            this.label17.TabIndex = 4;
            this.label17.Text = "Number Concentration PM10 [#/cm³]";
            // 
            // lblNPM05
            // 
            this.lblNPM05.AutoSize = true;
            this.lblNPM05.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPM05.Location = new System.Drawing.Point(753, 364);
            this.lblNPM05.Name = "lblNPM05";
            this.lblNPM05.Size = new System.Drawing.Size(103, 32);
            this.lblNPM05.TabIndex = 5;
            this.lblNPM05.Text = "###.##";
            // 
            // lblNPM100
            // 
            this.lblNPM100.AutoSize = true;
            this.lblNPM100.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPM100.Location = new System.Drawing.Point(753, 512);
            this.lblNPM100.Name = "lblNPM100";
            this.lblNPM100.Size = new System.Drawing.Size(103, 32);
            this.lblNPM100.TabIndex = 5;
            this.lblNPM100.Text = "###.##";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(463, 561);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(221, 22);
            this.label10.TabIndex = 4;
            this.label10.Text = "Typical Particle Size8 [µm]";
            // 
            // lblTPSize
            // 
            this.lblTPSize.AutoSize = true;
            this.lblTPSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPSize.Location = new System.Drawing.Point(753, 549);
            this.lblTPSize.Name = "lblTPSize";
            this.lblTPSize.Size = new System.Drawing.Size(103, 32);
            this.lblTPSize.TabIndex = 5;
            this.lblTPSize.Text = "###.##";
            // 
            // btnFanClean
            // 
            this.btnFanClean.Location = new System.Drawing.Point(593, 105);
            this.btnFanClean.Name = "btnFanClean";
            this.btnFanClean.Size = new System.Drawing.Size(117, 26);
            this.btnFanClean.TabIndex = 1;
            this.btnFanClean.Text = "Fan Clean";
            this.btnFanClean.UseVisualStyleBackColor = true;
            this.btnFanClean.Click += new System.EventHandler(this.btnFanClean_Click);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(164, 12);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(121, 30);
            this.cmbBaudRate.TabIndex = 0;
            // 
            // btnSendBuffer
            // 
            this.btnSendBuffer.Location = new System.Drawing.Point(460, 14);
            this.btnSendBuffer.Name = "btnSendBuffer";
            this.btnSendBuffer.Size = new System.Drawing.Size(174, 26);
            this.btnSendBuffer.TabIndex = 1;
            this.btnSendBuffer.Text = "Send Buffer";
            this.btnSendBuffer.UseVisualStyleBackColor = true;
            this.btnSendBuffer.Click += new System.EventHandler(this.btnSendBuffer_Click);
            // 
            // cmbBytes
            // 
            this.cmbBytes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBytes.FormattingEnabled = true;
            this.cmbBytes.Items.AddRange(new object[] {
            "256",
            "512",
            "1024",
            "2048",
            "4096"});
            this.cmbBytes.Location = new System.Drawing.Point(640, 14);
            this.cmbBytes.Name = "cmbBytes";
            this.cmbBytes.Size = new System.Drawing.Size(121, 30);
            this.cmbBytes.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(775, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bytes";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(183, 105);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 22);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "IDLE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "SPS30 Status:";
            // 
            // lblRevision
            // 
            this.lblRevision.AutoSize = true;
            this.lblRevision.Location = new System.Drawing.Point(183, 63);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(90, 22);
            this.lblRevision.TabIndex = 4;
            this.lblRevision.Text = "########";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "SPS30 Revision:";
            // 
            // btnGetRevision
            // 
            this.btnGetRevision.Location = new System.Drawing.Point(463, 63);
            this.btnGetRevision.Name = "btnGetRevision";
            this.btnGetRevision.Size = new System.Drawing.Size(171, 26);
            this.btnGetRevision.TabIndex = 1;
            this.btnGetRevision.Text = "Get version";
            this.btnGetRevision.UseVisualStyleBackColor = true;
            this.btnGetRevision.Click += new System.EventHandler(this.btnGetRevision_Click);
            // 
            // chkFormat
            // 
            this.chkFormat.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFormat.BackColor = System.Drawing.Color.Gray;
            this.chkFormat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.chkFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFormat.Location = new System.Drawing.Point(332, 141);
            this.chkFormat.Name = "chkFormat";
            this.chkFormat.Size = new System.Drawing.Size(104, 30);
            this.chkFormat.TabIndex = 6;
            this.chkFormat.Text = "HEX";
            this.chkFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFormat.UseVisualStyleBackColor = false;
            this.chkFormat.CheckedChanged += new System.EventHandler(this.chkFormat_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(928, 635);
            this.Controls.Add(this.chkFormat);
            this.Controls.Add(this.lblTPSize);
            this.Controls.Add(this.lblNPM100);
            this.Controls.Add(this.lblNPM40);
            this.Controls.Add(this.lblNPM25);
            this.Controls.Add(this.lblNPM10);
            this.Controls.Add(this.lblNPM05);
            this.Controls.Add(this.lblPM100);
            this.Controls.Add(this.lblPM40);
            this.Controls.Add(this.lblPM25);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPM10);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRevision);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkLoop);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnFanClean);
            this.Controls.Add(this.btnSendBuffer);
            this.Controls.Add(this.btnGetRevision);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbBytes);
            this.Controls.Add(this.cmbBaudRate);
            this.Controls.Add(this.cmbSerialPorts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPM10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPM25;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPM40;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPM100;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNPM10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNPM25;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblNPM40;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblNPM05;
        private System.Windows.Forms.Label lblNPM100;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTPSize;
        private System.Windows.Forms.Button btnFanClean;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Button btnSendBuffer;
        private System.Windows.Forms.ComboBox cmbBytes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGetRevision;
        private System.Windows.Forms.CheckBox chkFormat;
    }
}

