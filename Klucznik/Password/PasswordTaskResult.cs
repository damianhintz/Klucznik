using System;
using System.Collections.Generic;
using System.Text;
using Klucznik.Core;

namespace Klucznik.Password
{
    /// <summary>
    /// Wynik wykonania zadania, poszukiwania has³a
    /// </summary>
    [Serializable]
    class PasswordTaskResult : ITaskResult
    {
        public string Description
        {
            get { return "Has³o: " + _password; }
        }   

        private string _password;
        
        public PasswordTaskResult(string password)
        {
            _password = password;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
