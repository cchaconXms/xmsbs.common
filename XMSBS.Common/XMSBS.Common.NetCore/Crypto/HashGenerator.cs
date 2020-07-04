using System.Security.Cryptography;
using System.Text;

namespace XMSBS.Common.NetCore.Crypto
{
    public class HashGenerator
    {
        public string Generate(string plainText)
        {
            using (SHA256 shA256 = SHA256.Create())
            {
                byte[] hash = shA256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                StringBuilder stringBuilder = new StringBuilder();
                for (int index = 0; index < hash.Length; ++index)
                    stringBuilder.Append(hash[index].ToString("x2"));
                return stringBuilder.ToString();
            }
        }
    }
}