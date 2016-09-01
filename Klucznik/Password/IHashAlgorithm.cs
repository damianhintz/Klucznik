using System;
using System.Collections.Generic;
using System.Text;

namespace Klucznik.Password
{
    public interface IHashAlgorithm
    {
        string Hash(byte[] data, int index, int size);
    }
}
