namespace TcpUdpSpeedTesterServer
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.udpTransErrorBox = new System.Windows.Forms.TextBox();
            this.udpLostDataBox = new System.Windows.Forms.TextBox();
            this.udpTransmissionSpeedBox = new System.Windows.Forms.TextBox();
            this.udpStatCalcTimeBox = new System.Windows.Forms.TextBox();
            this.udpTotalTimeBox = new System.Windows.Forms.TextBox();
            this.udpTotalSizeBox = new System.Windows.Forms.TextBox();
            this.udpSingleDataSizeBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tcpTransErrorBox = new System.Windows.Forms.TextBox();
            this.tcpLostDataBox = new System.Windows.Forms.TextBox();
            this.tcpTransmissionSpeedBox = new System.Windows.Forms.TextBox();
            this.tcpStatCalcTimeBox = new System.Windows.Forms.TextBox();
            this.tcpTotalTimeBox = new System.Windows.Forms.TextBox();
            this.tcpTotalSizeBox = new System.Windows.Forms.TextBox();
            this.tcpSingleDataBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transmissions statistics";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(10, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Transmission error [%]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(10, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Lost data [bytes]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(10, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Transmission speed [kbytes/sec]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(10, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Statistics calculation time [msec]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(10, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total transmission time [sec]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(10, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total size of transfered data [kbytes]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Single data size [bytes]";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.udpTransErrorBox);
            this.groupBox3.Controls.Add(this.udpLostDataBox);
            this.groupBox3.Controls.Add(this.udpTransmissionSpeedBox);
            this.groupBox3.Controls.Add(this.udpStatCalcTimeBox);
            this.groupBox3.Controls.Add(this.udpTotalTimeBox);
            this.groupBox3.Controls.Add(this.udpTotalSizeBox);
            this.groupBox3.Controls.Add(this.udpSingleDataSizeBox);
            this.groupBox3.Location = new System.Drawing.Point(448, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 277);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "UDP";
            // 
            // udpTransErrorBox
            // 
            this.udpTransErrorBox.Location = new System.Drawing.Point(6, 238);
            this.udpTransErrorBox.Name = "udpTransErrorBox";
            this.udpTransErrorBox.Size = new System.Drawing.Size(123, 23);
            this.udpTransErrorBox.TabIndex = 13;
            // 
            // udpLostDataBox
            // 
            this.udpLostDataBox.Location = new System.Drawing.Point(6, 204);
            this.udpLostDataBox.Name = "udpLostDataBox";
            this.udpLostDataBox.Size = new System.Drawing.Size(123, 23);
            this.udpLostDataBox.TabIndex = 12;
            // 
            // udpTransmissionSpeedBox
            // 
            this.udpTransmissionSpeedBox.Location = new System.Drawing.Point(6, 172);
            this.udpTransmissionSpeedBox.Name = "udpTransmissionSpeedBox";
            this.udpTransmissionSpeedBox.Size = new System.Drawing.Size(123, 23);
            this.udpTransmissionSpeedBox.TabIndex = 11;
            // 
            // udpStatCalcTimeBox
            // 
            this.udpStatCalcTimeBox.Location = new System.Drawing.Point(6, 141);
            this.udpStatCalcTimeBox.Name = "udpStatCalcTimeBox";
            this.udpStatCalcTimeBox.Size = new System.Drawing.Size(123, 23);
            this.udpStatCalcTimeBox.TabIndex = 10;
            // 
            // udpTotalTimeBox
            // 
            this.udpTotalTimeBox.Location = new System.Drawing.Point(6, 107);
            this.udpTotalTimeBox.Name = "udpTotalTimeBox";
            this.udpTotalTimeBox.Size = new System.Drawing.Size(123, 23);
            this.udpTotalTimeBox.TabIndex = 9;
            // 
            // udpTotalSizeBox
            // 
            this.udpTotalSizeBox.Location = new System.Drawing.Point(6, 73);
            this.udpTotalSizeBox.Name = "udpTotalSizeBox";
            this.udpTotalSizeBox.Size = new System.Drawing.Size(123, 23);
            this.udpTotalSizeBox.TabIndex = 8;
            // 
            // udpSingleDataSizeBox
            // 
            this.udpSingleDataSizeBox.Location = new System.Drawing.Point(6, 36);
            this.udpSingleDataSizeBox.Name = "udpSingleDataSizeBox";
            this.udpSingleDataSizeBox.Size = new System.Drawing.Size(123, 23);
            this.udpSingleDataSizeBox.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.tcpTransErrorBox);
            this.groupBox2.Controls.Add(this.tcpLostDataBox);
            this.groupBox2.Controls.Add(this.tcpTransmissionSpeedBox);
            this.groupBox2.Controls.Add(this.tcpStatCalcTimeBox);
            this.groupBox2.Controls.Add(this.tcpTotalTimeBox);
            this.groupBox2.Controls.Add(this.tcpTotalSizeBox);
            this.groupBox2.Controls.Add(this.tcpSingleDataBox);
            this.groupBox2.Location = new System.Drawing.Point(293, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(135, 277);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TCP";
            // 
            // tcpTransErrorBox
            // 
            this.tcpTransErrorBox.Location = new System.Drawing.Point(6, 238);
            this.tcpTransErrorBox.Name = "tcpTransErrorBox";
            this.tcpTransErrorBox.Size = new System.Drawing.Size(123, 23);
            this.tcpTransErrorBox.TabIndex = 6;
            // 
            // tcpLostDataBox
            // 
            this.tcpLostDataBox.Location = new System.Drawing.Point(6, 204);
            this.tcpLostDataBox.Name = "tcpLostDataBox";
            this.tcpLostDataBox.Size = new System.Drawing.Size(123, 23);
            this.tcpLostDataBox.TabIndex = 5;
            // 
            // tcpTransmissionSpeedBox
            // 
            this.tcpTransmissionSpeedBox.Location = new System.Drawing.Point(6, 172);
            this.tcpTransmissionSpeedBox.Name = "tcpTransmissionSpeedBox";
            this.tcpTransmissionSpeedBox.Size = new System.Drawing.Size(123, 23);
            this.tcpTransmissionSpeedBox.TabIndex = 4;
            // 
            // tcpStatCalcTimeBox
            // 
            this.tcpStatCalcTimeBox.Location = new System.Drawing.Point(6, 141);
            this.tcpStatCalcTimeBox.Name = "tcpStatCalcTimeBox";
            this.tcpStatCalcTimeBox.Size = new System.Drawing.Size(123, 23);
            this.tcpStatCalcTimeBox.TabIndex = 3;
            // 
            // tcpTotalTimeBox
            // 
            this.tcpTotalTimeBox.Location = new System.Drawing.Point(6, 107);
            this.tcpTotalTimeBox.Name = "tcpTotalTimeBox";
            this.tcpTotalTimeBox.Size = new System.Drawing.Size(123, 23);
            this.tcpTotalTimeBox.TabIndex = 2;
            // 
            // tcpTotalSizeBox
            // 
            this.tcpTotalSizeBox.Location = new System.Drawing.Point(6, 73);
            this.tcpTotalSizeBox.Name = "tcpTotalSizeBox";
            this.tcpTotalSizeBox.Size = new System.Drawing.Size(123, 23);
            this.tcpTotalSizeBox.TabIndex = 1;
            // 
            // tcpSingleDataBox
            // 
            this.tcpSingleDataBox.Location = new System.Drawing.Point(6, 36);
            this.tcpSingleDataBox.Name = "tcpSingleDataBox";
            this.tcpSingleDataBox.Size = new System.Drawing.Size(123, 23);
            this.tcpSingleDataBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listening port:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(147, 13);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(470, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start listening";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(83, 15);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(46, 20);
            this.portBox.TabIndex = 3;
            this.portBox.Text = "7777";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 372);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "TCP/UDP Speed Tester Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox udpTransErrorBox;
        private System.Windows.Forms.TextBox udpLostDataBox;
        private System.Windows.Forms.TextBox udpTransmissionSpeedBox;
        private System.Windows.Forms.TextBox udpStatCalcTimeBox;
        private System.Windows.Forms.TextBox udpTotalTimeBox;
        private System.Windows.Forms.TextBox udpTotalSizeBox;
        private System.Windows.Forms.TextBox udpSingleDataSizeBox;
        private System.Windows.Forms.TextBox tcpTransErrorBox;
        private System.Windows.Forms.TextBox tcpLostDataBox;
        private System.Windows.Forms.TextBox tcpTransmissionSpeedBox;
        private System.Windows.Forms.TextBox tcpStatCalcTimeBox;
        private System.Windows.Forms.TextBox tcpTotalTimeBox;
        private System.Windows.Forms.TextBox tcpTotalSizeBox;
        private System.Windows.Forms.TextBox tcpSingleDataBox;
    }
}

