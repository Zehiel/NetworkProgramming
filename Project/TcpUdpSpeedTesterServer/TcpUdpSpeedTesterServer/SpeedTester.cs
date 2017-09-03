using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
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

        public SpeedTester(int port)
        {
            Port = port;
            IPHostEntry localHostEntry = Dns.GetHostByName(Dns.GetHostName());
            Console.WriteLine(localHostEntry.AddressList[0]);
            Console.WriteLine(localHostEntry.AddressList[1]);
            Console.WriteLine(localHostEntry.AddressList[2]);
            IP = localHostEntry.AddressList[2];
           // IP = IPAddress.Parse("127.0.0.1");
            try
            {
                Console.WriteLine("Starting speed tester");
//                tcpThread = new Thread(new ThreadStart(startTcpListening));
//                tcpThread.Start();
                udpThread = new Thread(new ThreadStart(startUdpListening));
                udpThread.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine("Thread error when starting speed tester");
                tcpThread.Abort();
                udpThread.Abort();
            }
        }
        

        public void startTcpListening()
        {
            try
            {
            TcpListener tcpListener = new TcpListener(IP,Port);

            Stopwatch stopWatchTCP = new Stopwatch();
                tcpListener.Start();
                while (true)
                {
                    
                    Console.WriteLine("Starting TCP listening");
                    stopWatchTCP.Reset();
                    Socket tcpSocket = tcpListener.AcceptSocket(); //client connected
                    Console.WriteLine("TCP client connected");
                    Byte[] initBuffer = new byte[512];
                    int initBytesReceived = tcpSocket.Receive(initBuffer, initBuffer.Length, 0);
                    String initialMsg = System.Text.Encoding.ASCII.GetString(initBuffer);
                    int bufforSize = Convert.ToInt32(initialMsg.Substring(5, initialMsg.Length-5));
                    Byte[] buffer = new byte[bufforSize];
                    Console.WriteLine("Reciving data from TCP client");
                    stopWatchTCP.Start();
                    int bytesReceived = tcpSocket.Receive(buffer, buffer.Length, 0);
                    stopWatchTCP.Stop();
                    Console.WriteLine("TCP data transfer finished");
                    int speed = Convert.ToInt32((bytesReceived * 8) / (stopWatchTCP.ElapsedMilliseconds + 0.1));
                    int time = Convert.ToInt32(stopWatchTCP.ElapsedMilliseconds / 1000);
                    int sizeKb = (bytesReceived * 8) / 1024;
                    Console.WriteLine("TCP Thread: " + sizeKb +"kb of data recived in time of: " + time + "sek with speed of " + speed + "kb/sec");
                    
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
                Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localIpEndPoint = new IPEndPoint(IP, Port);
                udpSocket.Bind(localIpEndPoint);
                Stopwatch stopWatchUDP = new Stopwatch();
                long totalTime = 0;

                while (true)
                {
                   
                    
                    Console.WriteLine("Starting UDP listening");
                    Byte[] initBuffer = new Byte[512];
                    IPEndPoint tmpIpEndPoint = new IPEndPoint(IP, Port);
                    EndPoint remoteEP = (tmpIpEndPoint);
                    int initBytesReceived = udpSocket.ReceiveFrom(initBuffer, ref remoteEP);
                    String initialMsg = System.Text.Encoding.ASCII.GetString(initBuffer);
                    int bufforSize = Convert.ToInt32(initialMsg.Substring(5, initialMsg.Length-5));
                    Byte[] buffer = new byte[bufforSize];

                    Console.WriteLine("Reciving data from UDP client");
                    while (true)
                    {
                        stopWatchUDP.Reset();
                        stopWatchUDP.Start();
                        int bytesReceived = udpSocket.ReceiveFrom(buffer, ref remoteEP);
                        stopWatchUDP.Stop();
                        Console.WriteLine("UDP data transfer finished");
                        int speed = Convert.ToInt32((bytesReceived * 8) / (stopWatchUDP.ElapsedMilliseconds + 0.1));
                        int time = Convert.ToInt32(stopWatchUDP.ElapsedMilliseconds / 1000);
                        totalTime += stopWatchUDP.ElapsedMilliseconds / 1000;
                        int sizeKb = (bytesReceived * 8) / 1024;
                        Console.WriteLine("UDP Thread: " + sizeKb + "kb of data recived in time of: " + time + "sek with speed of " + speed + "kb/sec");
                        Console.WriteLine("UDP Socket total time elapsed: " + totalTime);
                    }

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("A UDP Socket Exception occurred!" + e.ToString());
            }
        }
    }
}
