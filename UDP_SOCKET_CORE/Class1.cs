using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP_SOCKET_CORE
{
    public class UDPSocket
    {
        Socket _socket;
        const int BufferSize = 1024;


        public const int SIO_UDP_CONNRESET = 1744830452;

        public UDPSocket(string ipAddress, int portNum)
        {
            _socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
            _socket.IOControl((IOControlCode)SIO_UDP_CONNRESET,
                new byte[] { 0, 0, 0, 0 }, null);

            IPAddress parsedIpAddress = IPAddress.Parse(ipAddress);
            IPEndPoint serverEndPoint = new IPEndPoint(parsedIpAddress, portNum);
            _socket.Bind(serverEndPoint);

        }

        public string Listen()
        {
            // Listen for incoming messge
            byte[] receivedBytes = new byte[BufferSize];
            _socket.Receive(receivedBytes);

            // Log received message to user
            string receivedMessage = Encoding.ASCII.GetString(receivedBytes);
            return receivedMessage;
        }

        public void Send(string messageToSend, string ipAddress, int portNum)
        {
            // Send a Message to server
            IPAddress serverIPAddress = IPAddress.Parse(ipAddress);
            IPEndPoint serverEndPoint = new IPEndPoint(serverIPAddress, portNum);
            byte[] bytesToSend = Encoding.ASCII.GetBytes(messageToSend);
            _socket.SendTo(bytesToSend, serverEndPoint);
        }

        public string Echo()
        {
            //Listen for incoming message 
            byte[] receivedBytes = new byte[BufferSize];
            EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
            _socket.ReceiveFrom(receivedBytes, ref clientEndPoint);

            // Log received message to the user 
            string receivedMessage = Encoding.ASCII.GetString(receivedBytes);

            //Echo received message 
            _socket.SendTo(receivedBytes, clientEndPoint);

            return receivedMessage;
        }
    }
}
