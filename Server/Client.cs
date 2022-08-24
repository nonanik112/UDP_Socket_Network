using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        static void Maltego(string[] args)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23000);
            sock.Connect(endPoint);

            Console.Write("Enter Message: ");
            string msg = Console.ReadLine();
            byte[] msgBuffer = Encoding.Default.GetBytes(msg);
            sock.Send(msgBuffer, 0, msgBuffer.Length, 0);

            byte[] buffer = new byte[256];
            int rec = sock.Receive(buffer, 0, buffer.Length, 0);

            Array.Resize(ref buffer, rec);

            Console.Write("Received: {0}", Encoding.Default.GetString(buffer));

            Console.Read();
        }
    }
}
