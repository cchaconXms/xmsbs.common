using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace XMSBS.Common.NetCore.Crypto
{
    public class RandomString
    {
        public static string GenerateString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
                cryptoServiceProvider.GetBytes(bytes);
                foreach (byte num in bytes)
                    stringBuilder.AppendFormat("{0:x2}", (object) num);
            }
            return stringBuilder.ToString();
        }

        public static string GenerateString(string textPlain)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textPlain);
                cryptoServiceProvider.GetBytes(bytes);
                foreach (byte num in bytes)
                    stringBuilder.AppendFormat("{0:x2}", (object) num);
            }
            return stringBuilder.ToString();
        }
    }
}
