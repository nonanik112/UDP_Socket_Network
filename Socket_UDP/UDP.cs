using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket_UDP
{
    class UDP
    {
        public static string ip;
        public static string text;
        public static string txtfile;
        public static int count = 0;
        public static int port;
        static void Main4()
        {
            if (GetFile())
            {
                using (StreamReader sr = new StreamReader(txtfile))
                    text = sr.ReadToEnd();
                GetInfo();
                while (true)
                {
                    if (Send())
                    {
                        count++;
                        Console.WriteLine($"{count} Packet(s) have been send!");
                        Thread.Sleep(50);
                    }
                    else
                    {
                        Console.WriteLine($"Error while sending packets!", ConsoleColor.Red);
                        Thread.Sleep(50);
                    }
                }
            }
            else
            {
                Main4();
            }
        }

        public static bool Send()
        {
            byte[] packetData = Encoding.ASCII.GetBytes(text);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            try
            {
                sock.SendTo(packetData, ep);
                return true;
            }
            catch (SystemException syex)
            {

                return false;
            }
        }

        public static void GetInfo()
        {
            Console.WriteLine("IP: ");
            ip = Console.ReadLine();

            Console.WriteLine("Port: ");
            port = Convert.ToInt32(Console.ReadLine());
        }

        public static bool GetFile()
        {
            Console.WriteLine("Type the path to your .txt file:");
            txtfile = Console.ReadLine();

            if (File.Exists(txtfile)) return true;

            else return false;
        }
    }
}
