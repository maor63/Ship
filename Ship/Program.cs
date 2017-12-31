using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Ship s = new Ship();
            s.start();
        }

//        static int FreeTcpPort()
//        {
//            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
//            l.Start();
//            int port = ((IPEndPoint) l.LocalEndpoint).Port;
//            l.Stop();
//            return port;
//        }
//
//        public void Send()
//        {
//            UdpClient client = new UdpClient();
//            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 15000);
//            byte[] bytes = Encoding.ASCII.GetBytes("Foo");
//            client.Send(bytes, bytes.Length, ip);
//            client.Close();
//        }
    }
}