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
        private Boolean speedTesterStatus = false;

        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 500; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateData();
        }

        public Form1()
        {
            InitializeComponent();
            InitTimer();
            //tcpSingleDataBox.DataBindings.Add(new Binding("singleDataSize", speedTester.singleDataSizeTCP.ToString(), "singleDataSizeTCP"));
        }

        private void updateData()
        {
            tcpSingleDataBox.Text = this.speedTester.singleDataSizeTCP.ToString();
            tcpTotalSizeBox.Text = (this.speedTester.totalTransferedDataSizeTCP).ToString();
            tcpTotalTimeBox.Text = (this.speedTester.totalTransmissionTimeTCP/1000).ToString();
            tcpStatCalcTimeBox.Text = this.speedTester.statisticsCalculationTimeTCP.ToString();
            tcpTransmissionSpeedBox.Text = (this.speedTester.transmissionSpeedTCP).ToString();
            tcpLostDataBox.Text = this.speedTester.lostDataTCP.ToString();
            tcpTransErrorBox.Text = this.speedTester.transmissionErrorTCP.ToString();
            udpSingleDataBox.Text = this.speedTester.singleDataSizeUDP.ToString();
            udpTotalSizeBox.Text = (this.speedTester.totalTransferedDataSizeUDP).ToString();
            udpTotalTimeBox.Text = (this.speedTester.totalTransmissionTimeUDP/1000).ToString();
            udpStatCalcTimeBox.Text = this.speedTester.statisticsCalculationTimeUDP.ToString();
            udpTransmissionSpeedBox.Text = (this.speedTester.transmissionSpeedUDP).ToString();
            udpLostDataBox.Text = this.speedTester.lostDataUDP.ToString();
            udpTransErrorBox.Text = this.speedTester.transmissionErrorUDP.ToString();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            
           
            if (!this.speedTesterStatus)
            {
               
                if (this.speedTester.startListening(portBox.Text))
                {
                    this.speedTesterStatus = true;
                    startButton.Text = "Stop listening";
                }
            }
            else
            {
                this.speedTesterStatus = false;
                startButton.Text = "Start listening";
                this.speedTester.stopListening();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
