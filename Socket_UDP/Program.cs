using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDP_SOCKET_CORE;

namespace Socket_UDP
{
    class Program
    {
        private const int BufferSize = 1024;
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter 'S' for server 'C' for client ");

            string input = Console.ReadLine();

            if (input.Equals("s"))
            {
                Console.WriteLine("Starting server");
                UDPSocket server = new UDPSocket("175.17.0.1", 5000);
                string receivedMessage = server.Echo();
                Console.WriteLine($"Server received {receivedMessage}");
                //Server();
            }
            else if (input.Equals("c"))
            {
                Console.WriteLine("Starting client");
                UDPSocket client = new UDPSocket("175.17.0.1", 7000);
                client.Send("Hello", "175.17.0.1", 5000);
                string receivedMessage = client.Listen();
                Console.WriteLine($"Client received {receivedMessage}");
                //Client();
            }
            else
            {
                Console.WriteLine("Unexpected input!");
            }
            Console.WriteLine("Press any key to quit");
            Console.ReadLine();

        }
        //private static void Server()
        //{
        //    // Client();


        //    // Create server socket
        //    Socket serverSocket = CreateSocket("175.17.0.1", 5000);

        //    //Listen for incoming message 
        //    byte[] receivedBytes = new byte[BufferSize];
        //    EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
        //    serverSocket.ReceiveFrom(receivedBytes, ref clientEndPoint);

        //    // Log received message to the user 
        //    string receivedMessage = Encoding.ASCII.GetString(receivedBytes);
        //    Console.WriteLine(receivedMessage);

        //    //Echo received message 
        //    serverSocket.SendTo(receivedBytes, clientEndPoint);
        //    // Close Socket

        //}

        //public const int SIO_UDP_CONNRESET = 1744830452;

        //private static Socket CreateSocket(string ipAddress, int portNum)
        //{
        //    Socket socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
        //    socket.IOControl((IOControlCode)SIO_UDP_CONNRESET,
        //        new byte[] { 0, 0, 0, 0 }, null);

        //    IPAddress parsedIpAddress = IPAddress.Parse(ipAddress);
        //    //int serverPorNum = 5000;
        //    IPEndPoint serverEndPoint = new IPEndPoint(parsedIpAddress, portNum);
        //    socket.Bind(serverEndPoint);
        //    return socket;
        //}

        //private static void Client()
        //{
        //    // Create client Socket

        //    Socket clientSocket = CreateSocket("175.17.0.1", 7000);
        //    IPAddress clientIpAddress = IPAddress.Parse("175.17.0.1");
        //    int clentPorNum = 7000;
        //    IPEndPoint clientEndPoint = new IPEndPoint(clientIpAddress, clentPorNum);
        //    clientSocket.Bind(clientEndPoint);

        //    // Send a Message to server
        //    IPAddress serverIPAddress = IPAddress.Parse("175.17.0.1");
        //    int serverPortNum = 5000;
        //    IPEndPoint serverEndPoint = new IPEndPoint(serverIPAddress, serverPortNum);
        //    string messageToSend = "Selam";
        //    byte[] bytesToSend = Encoding.ASCII.GetBytes(messageToSend);
        //    clientSocket.SendTo(bytesToSend, serverEndPoint);

        //    // Listen for incoming messge
        //    byte[] receivedBytes = new byte[BufferSize];
        //    clientSocket.Receive(receivedBytes);

        //    // Log received message to user
        //    string receivedMessage = Encoding.ASCII.GetString(receivedBytes);
        //    Console.WriteLine(receivedMessage);
        //}
    }
}
