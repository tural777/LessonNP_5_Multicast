using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpMulticastClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var udpClient = new UdpClient(45679);
            var ip = IPAddress.Parse("224.5.6.7");
            udpClient.JoinMulticastGroup(ip);

            var ep = new IPEndPoint(ip, 45678);

            while (true)
            {
                var str = Console.ReadLine();
                var bytes = Encoding.Default.GetBytes(str);
                udpClient.Send(bytes, bytes.Length, ep);
            }
        }
    }
}
