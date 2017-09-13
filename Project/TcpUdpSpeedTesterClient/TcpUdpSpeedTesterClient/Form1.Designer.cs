namespace TcpUdpSpeedTesterClient
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
            this.IPBox = new System.Windows.Forms.TextBox();
            this.packetSizeBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.nagleBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(29, 14);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(123, 20);
            this.IPBox.TabIndex = 0;
            // 
            // packetSizeBox
            // 
            this.packetSizeBox.Location = new System.Drawing.Point(391, 14);
            this.packetSizeBox.Name = "packetSizeBox";
            this.packetSizeBox.Size = new System.Drawing.Size(90, 20);
            this.packetSizeBox.TabIndex = 1;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(207, 14);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(71, 20);
            this.portBox.TabIndex = 2;
            // 
            // nagleBox
            // 
            this.nagleBox.AutoSize = true;
            this.nagleBox.Location = new System.Drawing.Point(532, 16);
            this.nagleBox.Name = "nagleBox";
            this.nagleBox.Size = new System.Drawing.Size(54, 17);
            this.nagleBox.TabIndex = 3;
            this.nagleBox.Text = "Nagle";
            this.nagleBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.button1.Location = new System.Drawing.Point(13, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(599, 117);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start speed test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Packet size in bytes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 170);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nagleBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.packetSizeBox);
            this.Controls.Add(this.IPBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.TextBox packetSizeBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.CheckBox nagleBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

