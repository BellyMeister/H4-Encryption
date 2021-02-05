using Encryptinator9000;
using System;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 13356;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            RSAEncryption client = new RSAEncryption(ip, port);
            client.RecievedData += Write;
            Console.WriteLine("What u want fam?\n\"c\" to cancel");
            
            while (true)
            {
                string userInput = Console.ReadLine();
                client.WriteData(Encoding.UTF8.GetBytes(userInput));
                if (userInput.ToLower() == "c")
                {
                    break;
                }
            }
            client.Close();
        }

        private static void Write(object sender, byte[] e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e));
        }
        
    }
}