using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket_UDP
{
    class Program2
    {
        static void Main2(string[] args)
        {

            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAdr = IPAddress.Any;

            IPEndPoint ipep = new IPEndPoint(ipAdr, 23000);

            listenerSocket.Bind(ipep);

            listenerSocket.Listen(10);

            Console.WriteLine("About t occept incoming connection.");

            Socket client = listenerSocket.Accept();

            Console.WriteLine("Client connected" + client.ToString() + "- IP end Point: " + client.RemoteEndPoint.ToString());

            byte[] buff = new byte[128];

            int numberofReceivedBytes = 0;

            while (true)
            {

                numberofReceivedBytes = client.Receive(buff);

                Console.WriteLine("Number of recived bytes: " + numberofReceivedBytes);

                Console.WriteLine("Data sent by client is: " + buff);

                string receivedText = Encoding.ASCII.GetString(buff, 0, numberofReceivedBytes);

                Console.WriteLine("Data sent by client" + receivedText);

                client.Send(buff);

                if (receivedText == "x")
                {
                    break;
                }

                client.Send(buff);
                Array.Clear(buff, 0, buff.Length);
                numberofReceivedBytes = 0;
            }
        }
    }
}
