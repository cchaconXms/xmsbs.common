using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace XMSBS.Common.NetCore.Crypto
{
    public interface ISymmetric
    {
        ResultCrypto Encrypt<T>(string plainText) where T : SymmetricAlgorithm, new();
        ResultCrypto Decrypt<T>(string cipherText) where T : SymmetricAlgorithm, new();
    }
}
