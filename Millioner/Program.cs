using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Millioner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5656);
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("Waiting for a client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            data = newsock.Receive(ref sender);

            Console.WriteLine("Message received from {0}:", sender);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            string welcome = "IntroToNets";
            string shipname = "BlackPurl                                 ";
            data = Encoding.ASCII.GetBytes(welcome + shipname);
            newsock.Send(data, data.Length, sender);

//            while(true)
//            {
//                data = newsock.Receive(ref sender);
//
//                Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
//                newsock.Send(data, data.Length, sender);
//            }
        }
        
    }
}