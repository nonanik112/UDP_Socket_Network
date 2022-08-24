using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Server
{
    class Program
    {
        static void Maunt(string[] args)
        {
            #region "server"
            //Socket listener, connecter, acc;

            //listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //connecter = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23000));
            //listener.Listen(0);

            //new Thread(() =>
            //{
            //    acc = listener.Accept();
            //    Console.Write("Connected");
            //}).Start();
            //connecter.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23000));

            //Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23000));
            //sock.Listen(0);
            #endregion

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23000));
            sock.Listen(0);

            Socket acc = sock.Accept();

            byte[] buffer = Encoding.Default.GetBytes(">Hello  Client<");
            acc.Send(buffer, 0, buffer.Length, 0);

            byte[] recBuffer = new byte[255];

            int rec = acc.Receive(buffer, 0, buffer.Length, 0);

            Array.Resize(ref buffer, rec);

            Console.Write("Received: {0}", Encoding.Default.GetString(buffer));

            sock.Close();
            acc.Close();

            Console.Read();

        }
    }
}
