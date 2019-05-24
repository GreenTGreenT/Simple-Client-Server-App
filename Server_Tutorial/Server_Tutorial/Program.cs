using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 8000);
            TcpClient client = default(TcpClient);
            try
            {
                server.Start();
                Console.WriteLine("Server started...");
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
            while(true)
            {
                client = server.AcceptTcpClient();
                byte[] receiveBuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receiveBuffer, 0 , receiveBuffer.Length);
                string msg = Encoding.ASCII.GetString(receiveBuffer, 0, receiveBuffer.Length);
                Console.WriteLine(msg);
                Console.Read();

            }
        }
    }
}
