using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket_UDP
{
    class Mayin_Client
    {
        static Socket sock;
        static void Mapp(string[] args)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            try
            {
                sock.Connect(localEndPoint);
            }
            catch (Exception e)
            {

                Console.Write("Unable to connect to remote end point!\r\n");
                Mapp(args);
            }
            Console.Write("Enter Text: ");
            string text = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(text);

            sock.Send(data);
            Console.Write("Data Send!\r\n");
            Console.Write("Press any key to continue...");
            Console.Read();
            sock.Close();

        }
    }
}
