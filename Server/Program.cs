using Encryptinator9000;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Server
{
    class Program
    {
        public static List<RSAEncryption> clients = new List<RSAEncryption>();
        static void Main(string[] args)
        {
            int port = 13356;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);

            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();

            Console.WriteLine("Så venter vi jo bar\'");
            AcceptClients(listener);

            bool isRunning = true;
            Console.WriteLine("Skriv noget makker");
            while (isRunning)
            {
                string message = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(message);

                foreach (RSAEncryption client in clients)
                {
                    client.WriteData(buffer);
                }

                if (message.ToLower() == "c")
                {
                    Console.WriteLine("Conn closed");
                    break;
                }
            }
        }

        public static async void AcceptClients(TcpListener listener)
        {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                RSAEncryption etellerandet = new RSAEncryption(client);
                clients.Add(etellerandet);
                etellerandet.RecievedData += Write;
            }
        }

        private static void Write(object sender, byte[] e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e));
        }
    }
}
