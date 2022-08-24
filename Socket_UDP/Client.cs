using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket_UDP
{
    class Client
    {
        static void Mayin(string[] args)
        {
            Socket_Client client = new Socket_Client();

            Console.WriteLine("** Welcome to Socket Client Starter Example: ");
            Console.WriteLine("Please Type a Valid IP Address and Press Enter: ");

            string strIPAddress = Console.ReadLine();

            Console.WriteLine("Please Supply a Valid Port Number 0 65535 and Press Enter:  ");
            string strPortInput = Console.ReadLine();

            client.SetServerIPAddress(strIPAddress);
            client.SetPortNumber(strPortInput);


            if (!client.SetServerIPAddress(strIPAddress) || !client.SetPortNumber(strPortInput))
            {
                Console.WriteLine(string.Format("Wrong IP Address or port number spplied - {0} - {1} - Press a key to exit", strIPAddress));
                Console.ReadKey();
                return;
            }

            client.ConnectToServer();

            string strInputUser = null;

            do
            {
                strInputUser = Console.ReadLine();
            } while (strInputUser != "<EXİT>");
        }

    }
}
