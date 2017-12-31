using System;
using System.Collections;
using System.Collections.Generic;
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
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());  
            IPAddress ipAddress = ipHostInfo.AddressList[0];  
            
            List<Socket> acceptedSockets = new List<Socket>();
            
            
            Console.WriteLine("Waiting for a connection...");  
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);  
            Socket listener = new Socket(ipAddress.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);  
            listener.Listen(100);  
            Socket handler = listener.Accept();  
            acceptedSockets.Add(handler);
            Console.WriteLine(acceptedSockets.Count);
            Socket.Select(acceptedSockets, null, null, 1000);
            Console.WriteLine(acceptedSockets.Count);
            handler.Send(Encoding.ASCII.GetBytes("Hello"));
//            Console.WriteLine("Echoed text = {0}",  
//                System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRec));  


//            sendWelcomeBrodcast();
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