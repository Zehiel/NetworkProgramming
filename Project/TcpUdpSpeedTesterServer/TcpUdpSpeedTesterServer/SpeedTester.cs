using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TcpUdpSpeedTesterServer
{
    internal class SpeedTester
    {
        public int lostDataTCP;
        public int lostDataUDP;
        public int singleDataSizeTCP;
        public int singleDataSizeUDP;
        public long statisticsCalculationTimeTCP;
        public long statisticsCalculationTimeUDP;
        private TcpListener tcpListener;
        private bool tcpResetFlag;
        private Socket tcpSocket, udpSocket;
        private Thread tcpThread, udpThread;
        public int totalTransferedDataSizeTCP;
        public int totalTransferedDataSizeUDP;
        public long totalTransmissionTimeTCP;
        public long totalTransmissionTimeUDP;
        public int transmissionErrorTCP;
        public int transmissionErrorUDP;
        public long transmissionSpeedTCP;
        public long transmissionSpeedUDP;
        private bool udpResetFlag;

        /// <summary>
        /// Constructor, getting right IP address for Socket bindings
        /// </summary>
        public SpeedTester()
        {
            var localHostEntry = Dns.GetHostByName(Dns.GetHostName());
            Console.WriteLine(localHostEntry.AddressList[0]);
            Console.WriteLine(localHostEntry.AddressList[1]);
            Console.WriteLine(localHostEntry.AddressList[2]);
            IP = localHostEntry.AddressList[2];
            // IP = IPAddress.Parse("127.0.0.1");     
        }

        
        private int Port { get; set; }
        private IPAddress IP { get; }

        /// <summary>
        /// Method responsible for threads initialization, invoking stats reset and port input validation
        /// </summary>
        /// <param name="port">String represention from TextBox on form</param>
        /// <returns>boolean value indicating if threads were succesfully initialized</returns>
        public bool startListening(string port)
        {
            if (IsPort(port))
            {
                Port = Convert.ToInt32(port);
                try
                {
                    Console.WriteLine("Starting speed tester");
                    resetStats();
                    tcpThread = new Thread(startTcpListening);
                    tcpThread.Start();
                    udpThread = new Thread(startUdpListening);
                    udpThread.Start();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Thread error when starting speed tester");
                    return false;
                }
            }
            Console.WriteLine("Incorrect Port supplied");
            return false;
        }

        /// <summary>
        /// Method responsible for stoping listeners and sockets uppon listiner stop button click
        /// </summary>
        public void stopListening()
        {
            tcpResetFlag = true;
            udpResetFlag = true;
            if (tcpListener != null)
            {
                tcpListener.Stop();
                if (tcpSocket != null)
                    if (tcpSocket.IsBound)
                        tcpSocket.Close();
            }

            if (udpSocket != null)
                if (udpSocket.IsBound)
                    udpSocket.Close();
        }

        /// <summary>
        /// Method responsible for bulk cleaing fields visible on form
        /// </summary>
        private void resetStats()
        {
            singleDataSizeTCP = 0;
            totalTransferedDataSizeTCP = 0;
            totalTransmissionTimeTCP = 0;
            statisticsCalculationTimeTCP = 0;
            transmissionSpeedTCP = 0;
            lostDataTCP = 0;
            transmissionErrorTCP = 0;
            singleDataSizeUDP = 0;
            totalTransferedDataSizeUDP = 0;
            totalTransmissionTimeUDP = 0;
            statisticsCalculationTimeUDP = 0;
            transmissionSpeedUDP = 0;
            lostDataUDP = 0;
            transmissionErrorUDP = 0;
        }

        /// <summary>
        /// Method responsible for creating TCP Listener as well as mainting TCP Socket and data recipment
        /// </summary>
        public void startTcpListening()
        {
            try
            {
                tcpListener = new TcpListener(IP, Port);

                var stopWatchTCP = new Stopwatch();
                tcpListener.Start();
                while (true)
                {
                    if (tcpResetFlag)
                    {
                        tcpResetFlag = false;
                        break;
                    }
                    Console.WriteLine("Starting TCP listening");
                    tcpSocket = tcpListener.AcceptSocket(); //client connected
                    Console.WriteLine("TCP client connected");
                    var initBuffer = new byte[512];
                    var initBytesReceived = tcpSocket.Receive(initBuffer, initBuffer.Length, 0);
                    var initialMsg = Encoding.ASCII.GetString(initBuffer);
                    Console.WriteLine(initialMsg);
                    var bufforSize = Convert.ToInt32(initialMsg.Substring(5, initialMsg.Length - 5));
                    singleDataSizeTCP = bufforSize;
                    var buffer = new byte[bufforSize];
                    Console.WriteLine("Reciving data from TCP client");
                    while (true)
                        try
                        {
                            stopWatchTCP.Reset();
                            stopWatchTCP.Start();
                            var bytesReceived = tcpSocket.Receive(buffer, buffer.Length, 0);
                            stopWatchTCP.Stop();
                            //Console.WriteLine("TCP data transfer finished");
                            var speed = Convert.ToInt32(bytesReceived * 8 / (stopWatchTCP.ElapsedMilliseconds + 0.1));
                            var time = stopWatchTCP.ElapsedMilliseconds + 1;
                            var sizeKb = bytesReceived * 8 / 1024;
                            totalTransferedDataSizeTCP += sizeKb;
                            totalTransmissionTimeTCP += time;
                            transmissionSpeedTCP = (long) (totalTransferedDataSizeTCP /
                                                           (float) (totalTransmissionTimeTCP / 1000));
                            //Console.WriteLine("TCP Thread: " + sizeKb + "kb of data recived in time of: " + time + "sek with speed of " + speed + "kb/sec");
                            if (bytesReceived == 0 || tcpResetFlag)
                                break;
                        }
                        catch (SocketException e)
                        {
                            break;
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("TCP: Incorrect initial message");
                            break;
                        }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("A TCP Socket Exception occurred!" + e);
            }
        }

        /// <summary>
        /// Method responsible for UDP Socket creation and data recipment 
        /// </summary>
        public void startUdpListening()
        {
            try
            {
                udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                var localIpEndPoint = new IPEndPoint(IP, Port);
                udpSocket.Bind(localIpEndPoint);
                var stopWatchUDP = new Stopwatch();

                while (true)
                {
                    if (udpResetFlag)
                    {
                        udpResetFlag = false;
                        break;
                    }

                    Console.WriteLine("Starting UDP listening");
                    var initBuffer = new byte[512];
                    var tmpIpEndPoint = new IPEndPoint(IP, Port);
                    EndPoint remoteEP = tmpIpEndPoint;
                    var initBytesReceived = udpSocket.ReceiveFrom(initBuffer, ref remoteEP);
                    var initialMsg = Encoding.ASCII.GetString(initBuffer);
                    var bufforSize = Convert.ToInt32(initialMsg.Substring(5, initialMsg.Length - 5));
                    singleDataSizeUDP = bufforSize;
                    var buffer = new byte[bufforSize];

                    Console.WriteLine("Reciving data from UDP client");
                    while (true)
                        try
                        {
                            stopWatchUDP.Reset();
                            stopWatchUDP.Start();
                            var bytesReceived = udpSocket.ReceiveFrom(buffer, ref remoteEP);
                            stopWatchUDP.Stop();
                            //Console.WriteLine("UDP data transfer finished");
                            var speed = Convert.ToInt32(bytesReceived * 8 / (stopWatchUDP.ElapsedMilliseconds + 0.1));
                            var time = stopWatchUDP.ElapsedMilliseconds + 1;
                            var sizeKb = bytesReceived * 8 / 1024;
                            totalTransferedDataSizeUDP += sizeKb;
                            totalTransmissionTimeUDP += time;
                            transmissionSpeedUDP = (long) (totalTransferedDataSizeUDP /
                                                           (float) (totalTransmissionTimeUDP / 1000));
                            //Console.WriteLine("UDP Thread: " + sizeKb + "kb of data recived in time of: " + time + "sek with speed of " + speed + "kb/sec");
                            //Console.WriteLine("UDP Socket total time elapsed: " + totalTime);
                            var lastMsg = Encoding.ASCII.GetString(buffer);
                            if (lastMsg.Contains("FINE") || udpResetFlag)
                                break;
                        }
                        catch (SocketException e)
                        {
                            break;
                        }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("A UDP Socket Exception occurred!" + e);
            }
        }

        /// <summary>
        /// Validator for port number
        /// </summary>
        /// <param name="value">string representation of port provided by the user</param>
        /// <returns>boolean value indicating if provided string is valid port</returns>
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
    }
}