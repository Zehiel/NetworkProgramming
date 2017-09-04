using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpUdpSpeedTesterServer
{
    public partial class Form1 : Form
    {
        SpeedTester speedTester = new SpeedTester();

        public Form1()
        {
            InitializeComponent();
            //tcpSingleDataBox.DataBindings.Add(new Binding("singleDataSize", speedTester.singleDataSizeTCP.ToString(), "singleDataSizeTCP"));
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.speedTester.startListening(Convert.ToInt32(portBox.Text));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
