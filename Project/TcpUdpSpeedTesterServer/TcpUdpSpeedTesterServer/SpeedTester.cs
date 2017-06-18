using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            
            IP = localHostEntry.AddressList[0];
            //IP = IPAddress.Parse("127.0.0.1");
            try
            {
                tcpThread = new Thread(new ThreadStart(startTcpListening));
                tcpThread.Start();
                udpThread = new Thread(new ThreadStart(startUdpListening));
                udpThread.Start();

            }
            catch (Exception e)
            {
                tcpThread.Abort();
                udpThread.Abort();
            }
        }
        

        public void startTcpListening()
        {
            TcpListener tcpListener = new TcpListener(IP,Port);
            try
            {
                while (true)
                {
                    Socket tcpSocket = tcpListener.AcceptSocket(); //client connected
                    Byte[] initBuffer = new byte[512];
                    int initBytesReceived = tcpSocket.Receive(initBuffer, initBuffer.Length, 0);
                    String initialMsg = System.Text.Encoding.ASCII.GetString(initBuffer);
                    int bufforSize = int.Parse(initialMsg.Substring(5, initialMsg.Length));
                    Byte[] buffer = new byte[bufforSize];
                    int bytesReceived = tcpSocket.Receive(buffer, buffer.Length, 0);
                    startTcpListening();

                }
            }catch (SocketException e)
            {
                Console.WriteLine("A Socket Exception occurred!" + e.ToString());
            }
        }

        public void startUdpListening()
        {
            
            try
            {
                Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localIpEndPoint = new IPEndPoint(IP, Port);
                udpSocket.Bind(localIpEndPoint);

                while (true)
                {
                    Byte[] initBuffer = new Byte[512];
                    IPEndPoint tmpIpEndPoint = new IPEndPoint(IP, Port);
                    EndPoint remoteEP = (tmpIpEndPoint);
                    int initBytesReceived = udpSocket.ReceiveFrom(initBuffer, ref remoteEP);
                    String initialMsg = System.Text.Encoding.ASCII.GetString(initBuffer);
                    int bufforSize = int.Parse(initialMsg.Substring(5, initialMsg.Length));
                    Byte[] buffer = new byte[bufforSize];
                    int bytesReceived = udpSocket.ReceiveFrom(buffer, ref remoteEP);
                    startUdpListening();

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("A Socket Exception occurred!" + e.ToString());
            }
        }
    }
}
