using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpUdpSpeedTesterServer
{
    class SpeedTester
    {
        private int Port { get; set; }
        private IPAddress IP { get; set; }
        private Thread tcpThread, udpThread;
        public int singleDataSizeTCP = 0;
        public int totalTransferedDataSizeTCP = 0;
        public long totalTransmissionTimeTCP = 0;
        public long statisticsCalculationTimeTCP = 0;
        public long transmissionSpeedTCP = 0;
        public int lostDataTCP = 0;
        public int transmissionErrorTCP = 0;
        public int singleDataSizeUDP = 0;
        public int totalTransferedDataSizeUDP = 0;
        public long totalTransmissionTimeUDP = 0;
        public long statisticsCalculationTimeUDP = 0;
        public long transmissionSpeedUDP = 0;
        public int lostDataUDP = 0;
        public int transmissionErrorUDP = 0;
        private Socket tcpSocket, udpSocket;
        private Boolean tcpResetFlag = false;
        private Boolean udpResetFlag = false;
        private TcpListener tcpListener;


        public SpeedTester()
        {
            IPHostEntry localHostEntry = Dns.GetHostByName(Dns.GetHostName());
            Console.WriteLine(localHostEntry.AddressList[0]);
            Console.WriteLine(localHostEntry.AddressList[1]);
            Console.WriteLine(localHostEntry.AddressList[2]);
            IP = localHostEntry.AddressList[2];
            // IP = IPAddress.Parse("127.0.0.1");     
        }

        public bool startListening(string port)
        {
            if (IsPort(port))
            {
                this.Port = Convert.ToInt32(port);
                try
                {
                    Console.WriteLine("Starting speed tester");
                    resetStats();
                    tcpThread = new Thread(new ThreadStart(startTcpListening));
                    tcpThread.Start();
                    udpThread = new Thread(new ThreadStart(startUdpListening));
                    udpThread.Start();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Thread error when starting speed tester");
                    return false;

                }
               
            }
            else
            {
                Console.WriteLine("Incorrect Port supplied");
                return false;
            }
            
            
        }

        public void stopListening()
        {
            this.tcpResetFlag = true;
            this.udpResetFlag = true;
            if (this.tcpListener != null)
            {
                this.tcpListener.Stop();
                if (this.tcpSocket != null)
                {
                    if (this.tcpSocket.IsBound)
                    {
                        this.tcpSocket.Close();
                    }
                }
            }
            
            if (this.udpSocket != null)
            {
                if (this.udpSocket.IsBound)
                {
                    this.udpSocket.Close();
                }
            }
            
            
        }

        void resetStats()
        {
            this.singleDataSizeTCP = 0;
            this.totalTransferedDataSizeTCP = 0;
            this.totalTransmissionTimeTCP = 0;
            this.statisticsCalculationTimeTCP = 0;
            this.transmissionSpeedTCP = 0;
            this.lostDataTCP = 0;
            this.transmissionErrorTCP = 0;
            this.singleDataSizeUDP = 0;
            this.totalTransferedDataSizeUDP = 0;
            this.totalTransmissionTimeUDP = 0;
            this.statisticsCalculationTimeUDP = 0;
            this.transmissionSpeedUDP = 0;
            this.lostDataUDP = 0;
            this.transmissionErrorUDP = 0;
    }
        

        public void startTcpListening()
        {
            try
            {
            this.tcpListener = new TcpListener(IP,Port);

            Stopwatch stopWatchTCP = new Stopwatch();
                this.tcpListener.Start();
                while (true)
                {
                    if (this.tcpResetFlag)
                    {
                        this.tcpResetFlag = false;
                        break;
                    }
                    Console.WriteLine("Starting TCP listening");
                    this.tcpSocket = this.tcpListener.AcceptSocket(); //client connected
                    Console.WriteLine("TCP client connected");
                    Byte[] initBuffer = new byte[512];
                    int initBytesReceived = this.tcpSocket.Receive(initBuffer, initBuffer.Length, 0);
                    String initialMsg = System.Text.Encoding.ASCII.GetString(initBuffer);
                    Console.WriteLine(initialMsg);
                    int bufforSize = Convert.ToInt32(initialMsg.Substring(5, initialMsg.Length-5));
                    singleDataSizeTCP = bufforSize;
                    Byte[] buffer = new byte[bufforSize];
                    Console.WriteLine("Reciving data from TCP client");
                    while (true)
                    {
                        try
                        {

                            stopWatchTCP.Reset();
                            stopWatchTCP.Start();
                            int bytesReceived = this.tcpSocket.Receive(buffer, buffer.Length, 0);
                            stopWatchTCP.Stop();
                            //Console.WriteLine("TCP data transfer finished");
                            int speed = Convert.ToInt32((bytesReceived * 8) / (stopWatchTCP.ElapsedMilliseconds + 0.1));
                            long time = stopWatchTCP.ElapsedMilliseconds + 1;
                            int sizeKb = (bytesReceived * 8) / 1024;
                            totalTransferedDataSizeTCP += sizeKb;
                            totalTransmissionTimeTCP += time;
                            transmissionSpeedTCP = (long) (totalTransferedDataSizeTCP /
                                                           (float) (totalTransmissionTimeTCP / 1000));
                            //Console.WriteLine("TCP Thread: " + sizeKb + "kb of data recived in time of: " + time + "sek with speed of " + speed + "kb/sec");
                            if (bytesReceived == 0 || tcpResetFlag)
                            {
                                break;
                            }
                        }
                        catch (SocketException e)
                        {
                            break;
                        }
                        catch (System.FormatException e)
                        {
                            break;
                            Console.WriteLine("TCP: Incorrect initial message");
                        }
                    }

                }
            }catch (SocketException e)
            {
                
                Console.WriteLine("A TCP Socket Exception occurred!" + e.ToString());
            }
        }

        public void startUdpListening()
        {
            
            try
            {
                this.udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localIpEndPoint = new IPEndPoint(IP, Port);
                udpSocket.Bind(localIpEndPoint);
                Stopwatch stopWatchUDP = new Stopwatch();

                while (true)
                {
                    if (this.udpResetFlag)
                    {
                        this.udpResetFlag = false;
                        break;
                    }
                    
                    Console.WriteLine("Starting UDP listening");
                    Byte[] initBuffer = new Byte[512];
                    IPEndPoint tmpIpEndPoint = new IPEndPoint(IP, Port);
                    EndPoint remoteEP = (tmpIpEndPoint);
                    int initBytesReceived = this.udpSocket.ReceiveFrom(initBuffer, ref remoteEP);
                    String initialMsg = System.Text.Encoding.ASCII.GetString(initBuffer);
                    int bufforSize = Convert.ToInt32(initialMsg.Substring(5, initialMsg.Length-5));
                    singleDataSizeUDP = bufforSize;
                    Byte[] buffer = new byte[bufforSize];

                    Console.WriteLine("Reciving data from UDP client");
                    while (true)
                    {
                        try
                        {
                            stopWatchUDP.Reset();
                            stopWatchUDP.Start();
                            int bytesReceived = this.udpSocket.ReceiveFrom(buffer, ref remoteEP);
                            stopWatchUDP.Stop();
                            //Console.WriteLine("UDP data transfer finished");
                            int speed = Convert.ToInt32((bytesReceived * 8) / (stopWatchUDP.ElapsedMilliseconds + 0.1));
                            long time = stopWatchUDP.ElapsedMilliseconds + 1;
                            int sizeKb = (bytesReceived * 8) / 1024;
                            totalTransferedDataSizeUDP += sizeKb;
                            totalTransmissionTimeUDP += time;
                            transmissionSpeedUDP = (long)(totalTransferedDataSizeUDP / (float)(totalTransmissionTimeUDP/1000));
                            //Console.WriteLine("UDP Thread: " + sizeKb + "kb of data recived in time of: " + time + "sek with speed of " + speed + "kb/sec");
                            //Console.WriteLine("UDP Socket total time elapsed: " + totalTime);
                            String lastMsg = System.Text.Encoding.ASCII.GetString(buffer);
                            if (lastMsg.Contains("FINE") || this.udpResetFlag)
                            {
                                break;
                            }
                        }
                        catch (SocketException e)
                        {
                            break;
                        }
                        
                    }

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("A UDP Socket Exception occurred!" + e.ToString());
            }
        }

        public static bool IsPort(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            Regex numeric = new Regex(@"^[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (numeric.IsMatch(value))
            {
                try
                {
                    if (Convert.ToInt32(value) < 65536)
                        return true;
                }
                catch (OverflowException)
                {
                }
            }

            return false;
        }
    }
}
