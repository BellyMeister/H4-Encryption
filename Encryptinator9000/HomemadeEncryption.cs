using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Encryptinator9000
{
    public class HomemadeEncryption
    {
        public static string key = "uqghowzeavpytdrbfjkxlnsimc";
        static void Main()
        {
            string plainText = "the quick brown fox jumps over the lazy dog";
            byte[] encryptedBytes = EncryptByte(Encoding.UTF8.GetBytes(plainText));
            string cipherText = Encoding.UTF8.GetString(encryptedBytes);
            string decryptedText = Encoding.UTF8.GetString(EncryptByte(Encoding.UTF8.GetBytes(cipherText)));

            Console.WriteLine($"Plain     : {plainText}");
            Console.WriteLine($"Encrypted : {cipherText}");
            Console.WriteLine($"Decrypted : {plainText}");
            Console.ReadKey();
        }

        public static byte[] EncryptByte(byte[] bytes)
        {
            byte[] chars = new byte[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x20)
                {
                    chars[i] = (byte)0x20;
                }
                else
                {
                    int j = bytes[i] - 97;
                    chars[i] = (byte)key[j];
                }
            }
            return chars;
        }

        public static byte[] DecryptByte(byte[] bytes)
        {
            byte[] chars = new byte[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x20)
                {
                    chars[i] = (byte)0x20;
                }
                else
                {
                    int j = bytes[i] + 97;
                    chars[i] = (byte)j;
                }
            }
            return chars;
        }
    }
}
