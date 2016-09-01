using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Klucznik.Password
{
    [Serializable]
    public class MD5HashAlgorithm : IHashAlgorithm
    {
        private static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        public string Hash(byte[] data, int index, int size)
        {
            byte[] hash = md5.ComputeHash(data, index, size);
            StringBuilder s = new StringBuilder();
            foreach (byte b in hash)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        public override string ToString()
        {
            return "MD5";
        }
    }
}
