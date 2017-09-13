using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TcpUdpSpeedTesterClient
{
    internal class SpeedTester
    {
        private byte[] data;
        private byte[] initalData;
        private Thread tcpThread, udpThread;
        private int Port { get; set; }
        private string IP { get; set; }
        private int packetSize { get; set; }


        public void startSpeedTester(string IP, string Port, string PacketSize, bool Nagle)
        {
            int result;
            if (isValidIP(IP) && IsPort(Port) && int.TryParse(PacketSize, out result) && result != 0)
            {
                initalData = prepareFirstMessage(Convert.ToInt32(Port));
                data = generateData(Convert.ToInt32(PacketSize));
                this.IP = IP;
                this.Port = Convert.ToInt32(Port);
                packetSize = Convert.ToInt32(PacketSize);
                startConnections();
            }
            else
            {
                Console.WriteLine(
                    "Error parsing Speed Tester arguments, please double check IP, Port and Packet Size ");
            }
        }

        private byte[] generateData(int size)
        {
            var random = new Random();
            var data = new byte[size];
            random.NextBytes(data);
            return data;
        }

        private void startConnections()
        {
            tcpThread = new Thread(startTcpConnection);
            tcpThread.Start();
            udpThread = new Thread(startUdpConnection);
            udpThread.Start();
        }

        private void startTcpConnection()
        {
            try
            {
                while (true)
                {
                    var client = new TcpClient(IP, Port);

                    var initialData = prepareFirstMessage(packetSize);
                    var data = generateData(packetSize);


                    var stream = client.GetStream();
                    stream.Write(initialData, 0, initialData.Length);

                    while (true)
                        stream.Write(data, 0, data.Length);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (IOException e)
            {
                Console.WriteLine("Socket has been closed by host");
            }
        }

        private void startUdpConnection()
        {
            try
            {
                while (true)
                {
                    var udpClient = new UdpClient(Port);
                    udpClient.Connect(IP, Port);

                    var initialData = prepareFirstMessage(packetSize);
                    var data = generateData(packetSize);

                    udpClient.Send(initialData, initialData.Length);

                    while (true)
                        udpClient.Send(data, data.Length);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        private byte[] prepareFirstMessage(int size)
        {
            var msg = "SIZE:" + size;
            return Encoding.ASCII.GetBytes(msg);
        }

        public static bool IsPort(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            var numeric = new Regex(@"^[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (numeric.IsMatch(value))
                try
                {
                    if (Convert.ToInt32(value) < 65536)
                        return true;
                }
                catch (OverflowException)
                {
                }

            return false;
        }

        public static bool isValidIP(string value)
        {
            return Regex.IsMatch(value,
                "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        }
    }
}