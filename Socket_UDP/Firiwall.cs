using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Socket_UDP
{
    class Firiwall
    {
        static void Udp(string[] args)
        {
            int lport = int.Parse(args[0]);

            using (UdpClient listener = new UdpClient(lport))
            {
                IPEndPoint localEp = new IPEndPoint(IPAddress.Any, lport);
                string cmd;
                byte[] input;
                while (true)
                {
                    input = listener.Receive(ref localEp);
                    cmd = Encoding.ASCII.GetString(input, 0, input.Length);

                    if (string.IsNullOrEmpty(cmd))
                    {
                        listener.Close();
                        return;
                    }
                    if (string.IsNullOrEmpty(cmd)) continue;

                    string[] split = cmd.Trim().Split(' ');
                    string filename = split.First();
                    string arg = string.Join(" ", split.Skip(1));
                    string results = string.Empty;
                }
            }


        }

    }
}
