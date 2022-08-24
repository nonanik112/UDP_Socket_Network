using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket_UDP
{
    public class Socket_Client
    {
        IPAddress mServerIpAddress;
        int mServerPort;
        TcpClient mClient;

        public Socket_Client()
        {
            mClient = null;
            mServerPort = -1;
            mServerIpAddress = null;
        }

        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIpAddress;
            }
        }

        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }
        public bool SetServerIPAddress(string _IPAddressServer)
        {
            IPAddress ipadr = null;
            if (!IPAddress.TryParse(_IPAddressServer, out ipadr))
            {
                Console.WriteLine("Invalid server IP supplied");
                return false;
            }
            return true;
        }
        public bool SetPortNumber(string _ServerPort)
        {
            int portNumber = 0;

            if (!int.TryParse(_ServerPort.Trim(), out portNumber))
            {
                Console.WriteLine("Invalid port number supplied, return.");
                return false;
            }

            if (portNumber <= 0 || portNumber > 65535)
            {
                Console.WriteLine("Port number must e between 0 and 65535.");
                return false;

            }
            mServerPort = portNumber;

            return true;

        }

        public async Task ConnectToServer()
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }
            try
            {
                await mClient.ConnectAsync(mServerIpAddress, mServerPort);
                Console.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}", mServerIpAddress, mServerPort));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
