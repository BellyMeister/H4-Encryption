using System;
using System.Collections.Generic;
using System.Text;

namespace Encryptinator9000
{
    class NonParametricEncryption
    {
        public static byte[] encryptedMessage(byte[] buffer, bool isEncrypted)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                if (isEncrypted)
                    buffer[i] -= 3;
                else
                    buffer[i] += 3;
            }
            return buffer;
        }
    }
}
