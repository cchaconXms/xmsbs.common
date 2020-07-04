using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace XMSBS.Common.Crypto
{
    public class ContextCrypto
    {
        private readonly ISymmetric symmetric;

        public ContextCrypto()
        {
            symmetric = new Symmetric();
        }

        public ResultCrypto Encrypt<T>(string plaintText) where T : SymmetricAlgorithm, new()
        {
            return symmetric.Encrypt<T>(plaintText);
        }

        public ResultCrypto Decrypt<T>(string cipherText) where T : SymmetricAlgorithm, new()
        {
            return symmetric.Decrypt<T>(cipherText);
        }
    }
}
