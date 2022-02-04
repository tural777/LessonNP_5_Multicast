using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpMulticastServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var udpClient = new UdpClient(45678);
            var ip = IPAddress.Parse("224.5.6.7");
            udpClient.JoinMulticastGroup(ip);

            var ep = new IPEndPoint(ip, 0);

            while (true)
            {
                var bytes = udpClient.Receive(ref ep);

                var str = Encoding.Default.GetString(bytes);
                Console.WriteLine(str);
            }
        }
    }
}
