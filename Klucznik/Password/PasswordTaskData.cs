using System;
using System.Collections.Generic;
using System.Text;
using Klucznik.Core;

namespace Klucznik.Password
{
    /// <summary>
    /// 
    /// </summary>
    public class PasswordTaskData : ITaskData
    {
        private PasswordCharset _charset;
        public PasswordCharset Charset
        {
            get { return _charset; }
        }

        private string _hash;
        public string Hash
        {
            get { return _hash; }
        }

        private IHashAlgorithm _iha;
        public IHashAlgorithm HashAlgorithm
        {
            get { return _iha; }
        }

        private Password _minPass;
        public Password MinPass
        {
            get { return _minPass; }
        }

        private Password _maxPass;
        public Password MaxPass
        {
            get { return _maxPass; }
        }

        public PasswordTaskData(PasswordCharset charset, Password minPass, Password maxPass, string hash, IHashAlgorithm iha)
        {
            _charset = charset;
            _minPass = minPass;
            _maxPass = maxPass;
            _hash = hash;
            _iha = iha;
        }
    }
}
