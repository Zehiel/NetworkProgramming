using System;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Windows.Forms;


namespace EchoClient
{
    public partial class Form1 : Form
    {
        TCPClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IPInputBox.Text == "")
                {
                    throw new ArgumentNullException();
                }
                else if (portInputBox.Text == "")
                {
                    throw new ArgumentOutOfRangeException();
                }

                client = new TCPClient(IPInputBox.Text, Int32.Parse(portInputBox.Text));
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (ArgumentNullException) {
                consoleBox.AppendText("ERROR:No address typed in!");
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (ArgumentOutOfRangeException) {
                consoleBox.AppendText("ERROR:Incorrect port number");
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (SocketException exc)
            {
                consoleBox.AppendText("ERROR:Couldn't access socket! " + exc.Message);
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (ObjectDisposedException)
            {
                consoleBox.AppendText("ERROR:Socket has been closed!");
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (NotSupportedException)
            {
                consoleBox.AppendText("ERROR:Wrong address type, please use IPv4 or IPv6 address!");
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (ArgumentException)
            {
                consoleBox.AppendText("ERROR:Incorrect address!");
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (InvalidOperationException)
            {
                consoleBox.AppendText("ERROR:Socket is in listener mode!");
                consoleBox.AppendText(Environment.NewLine);
            }
             

        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;           
            client.Release();
            consoleBox.AppendText("Disconnected from the server");
            consoleBox.AppendText(Environment.NewLine);
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (msgInputBox.Text == "")
                {
                    throw new ArgumentNullException();
                }
                await client.SendMSG(msgInputBox.Text, consoleBox);
                consoleBox.AppendText("Sent to the server:" + msgInputBox.Text);
                consoleBox.AppendText(Environment.NewLine);
                msgInputBox.Clear();
            }
            catch (ArgumentNullException)
            {
                consoleBox.AppendText("ERROR:Nothing to send!");
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (SocketException)
            {
                consoleBox.AppendText("ERROR:Couldn't access socket!");
                consoleBox.AppendText(Environment.NewLine);
            }
            catch (ObjectDisposedException)
            {
                consoleBox.AppendText("ERROR:Socket has been closed!");
                consoleBox.AppendText(Environment.NewLine);
                connectButton.Enabled = true;
                disconnectButton.Enabled = false;
                sendButton.Enabled = false;
                client.Release();
            }
            catch (SecurityException)
            {
                consoleBox.AppendText("ERROR:No permissions to run this method!");
                consoleBox.AppendText(Environment.NewLine);
            }
           
            
        }
    }  

    
}
