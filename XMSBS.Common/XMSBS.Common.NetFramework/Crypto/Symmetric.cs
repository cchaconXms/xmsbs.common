using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace XMSBS.Common.Crypto
{
    class Symmetric : ISymmetric 
    {
        private const string initVector = "asdqwe123asdqwe1";

        private const int keysize = 256;

        public ResultCrypto Decrypt<T>(string cipherText) where T : SymmetricAlgorithm, new()
        {
            string[] keyvalue = cipherText.Split('|');
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(keyvalue[1]);
            PasswordDeriveBytes password = new PasswordDeriveBytes(keyvalue[0], null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            byte[] plainTextBytes = null;
            int decryptedByteCount = 0;

            using (var symmetricKey = new T())
            {
                symmetricKey.Mode = CipherMode.ECB;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                plainTextBytes = new byte[cipherTextBytes.Length];
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
            }

            return new ResultCrypto() { Value = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount) };
        }

        public ResultCrypto Encrypt<T>(string plainText) where T : SymmetricAlgorithm, new()
        {
            string codeRandom = RandomString.GenerateString(20);
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(codeRandom, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            byte[] cipherTextBytes = null;
            using (var symmetricKey = new T())
            {
                symmetricKey.Mode = CipherMode.ECB;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
            }

            var resultString = Convert.ToBase64String(cipherTextBytes);
            return new ResultCrypto() { Value = codeRandom + "|" + resultString };
        }
    }
}
