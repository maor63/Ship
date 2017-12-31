using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    public class Ship
    {
        public void start()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            TcpListener server = new TcpListener(IPAddress.Any, 20000);
            server.Start();
//            TcpClient client = server.AcceptTcpClient();
            Task<TcpClient> c =  server.AcceptTcpClientAsync();
            TcpClient e = c.Result;
            
            
            Console.WriteLine("Connected!");

            
            sendWelcomeBrodcast();
        }

        private void sendWelcomeBrodcast()
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 5656);

            string welcome = "IntroToNets";
            string shipname = "BlackPurl                       ";
            string welcomMsg = welcome + shipname;
            char[] welcomCharArray = welcomMsg.ToCharArray();


            ushort port = 1000;
            byte[] portBytes = BitConverter.GetBytes(port);
            Console.WriteLine(BitConverter.ToInt16(portBytes, 0));

            byte[] shipNameBytes = Encoding.ASCII.GetBytes(welcomCharArray);
            Console.WriteLine(shipNameBytes.Length);

            byte[] bytes = new byte[shipNameBytes.Length + portBytes.Length];


            shipNameBytes.CopyTo(bytes, 0);
            portBytes.CopyTo(bytes, shipNameBytes.Length);

            client.Send(bytes, bytes.Length, ip);
            client.Close();
        }
    }
}