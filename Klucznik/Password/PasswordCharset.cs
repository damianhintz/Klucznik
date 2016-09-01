using System;
using System.Collections.Generic;
using System.Text;

namespace Klucznik.Password
{
    /// <summary>
    /// Zbi�r znak�w z kt�rych mog� by� tworzone has�a
    /// </summary>
    [Serializable]
    public class PasswordCharset
    {
        private const int _size = 256;

        /// <summary>
        /// Litery alfabetu
        /// </summary>
        private readonly string _charset;
        public string Charset
        {
            get { return _charset; }
        }

        /// <summary>
        /// Tablica na warto�ci liter alfabetu.
        /// Kolejne litery alfabetu otrzymuj� warto�ci odpowiednio 0, 1, 2,...
        /// </summary>
        private readonly int[] _values = new int[_size];
        public int[] Values
        {
            get { return _values; }
        }

        /// <summary>
        /// D�ugo�� alfabetu
        /// </summary>
        public int Length
        {
            get { return _charset.Length; }
        }

        public PasswordCharset(string charset)
        {
        	_charset = charset;
			for(int i = 0;i < _size;i++)
			{
				_values[i] = -1;
			}
			for(int i = 0;i < _charset.Length;i++)
			{
				_values[_charset[i]] = i;
			}
        }
    }
}
