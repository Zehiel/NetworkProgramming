namespace EchoServer
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clients_counter_display = new System.Windows.Forms.Label();
            this.listening_port_desc = new System.Windows.Forms.Label();
            this.listening_port_box = new System.Windows.Forms.TextBox();
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(543, 387);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clients count: ";
            // 
            // clients_counter_display
            // 
            this.clients_counter_display.AutoSize = true;
            this.clients_counter_display.Location = new System.Drawing.Point(92, 40);
            this.clients_counter_display.Name = "clients_counter_display";
            this.clients_counter_display.Size = new System.Drawing.Size(0, 13);
            this.clients_counter_display.TabIndex = 2;
            // 
            // listening_port_desc
            // 
            this.listening_port_desc.AutoSize = true;
            this.listening_port_desc.Location = new System.Drawing.Point(12, 13);
            this.listening_port_desc.Name = "listening_port_desc";
            this.listening_port_desc.Size = new System.Drawing.Size(70, 13);
            this.listening_port_desc.TabIndex = 3;
            this.listening_port_desc.Text = "Listening port";
            // 
            // listening_port_box
            // 
            this.listening_port_box.Location = new System.Drawing.Point(88, 12);
            this.listening_port_box.Name = "listening_port_box";
            this.listening_port_box.Size = new System.Drawing.Size(100, 20);
            this.listening_port_box.TabIndex = 4;
            this.listening_port_box.Text = "7";
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(399, 13);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 5;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            // 
            // stop_button
            // 
            this.stop_button.Enabled = false;
            this.stop_button.Location = new System.Drawing.Point(480, 13);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(75, 23);
            this.stop_button.TabIndex = 6;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 455);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.listening_port_box);
            this.Controls.Add(this.listening_port_desc);
            this.Controls.Add(this.clients_counter_display);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label clients_counter_display;
        private System.Windows.Forms.Label listening_port_desc;
        private System.Windows.Forms.TextBox listening_port_box;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
    }
}

