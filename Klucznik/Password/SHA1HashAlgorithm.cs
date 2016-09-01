using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Klucznik.Password
{
    [Serializable]
    public class SHA1HashAlgorithm : IHashAlgorithm
    {
        private static SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

        public string Hash(byte[] data, int index, int size)
        {
            byte[] hash = sha1.ComputeHash(data, index, size);
            StringBuilder s = new StringBuilder();
            foreach (byte b in hash)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        public override string ToString()
        {
            return "SHA1";
        }
    }
}
