using System;
using System.Collections.Generic;
using System.Text;

namespace Encryptinator9000
{
    public class PrivateKeyEncryption
    {
        public static byte[] EncryptByte(byte[] bytes, byte key = 255)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                int change = i + key;
                while (change + bytes[i] > key) change -= 256;
                bytes[i] += (byte)change;
            }
            return bytes;
        }

        public static byte[] DecryptByte(byte[] bytes, byte key = 255)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                int change = i + key;
                while (change - bytes[i] < 0) change += 256;
                bytes[i] -= (byte)change;
            }
            return bytes;
        }
    }
}
