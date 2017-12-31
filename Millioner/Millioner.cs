using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Millioner
{
    public class Millioner
    {
        public void start()
        {
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5656);
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("Looking for a new boat…");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            data = newsock.Receive(ref sender);

            Console.WriteLine("Message received from {0}:", sender);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, 32 + 11));
            Console.WriteLine(data.Length);
            Console.WriteLine(BitConverter.ToInt16(data,43));
            
            
        }
    }
}