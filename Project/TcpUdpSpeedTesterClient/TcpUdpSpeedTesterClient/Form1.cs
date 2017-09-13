using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpUdpSpeedTesterClient
{
    public partial class Form1 : Form
    {
        private SpeedTester speedTester;
        public Form1()
        {
            InitializeComponent();
            speedTester = new SpeedTester();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            speedTester.startSpeedTester(this.IPBox.Text,this.portBox.Text,this.packetSizeBox.Text,this.nagleBox.Checked);
        }
    }
}
