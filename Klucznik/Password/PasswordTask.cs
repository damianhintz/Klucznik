using System;
using System.Collections.Generic;
using System.Text;
using Klucznik.Core;

namespace Klucznik.Password
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PasswordTask : ITask
    {
        #region Fields

        private int _TaskId;
        public int TaskId
        {
            get { return _TaskId; }
        }

        private DateTime _ExpireTime;
        public DateTime ExpireTime
        {
            get { return _ExpireTime; }
            set { _ExpireTime = value; }
        }

        private Password _maxPass;
        private Password _minPass;
        private string _hash;
        private ulong _size;
        private bool _stoped = false;

        public string Description
        {
            get 
            { 
                return string.Format(
                    "Zbiór znaków: {0}\nMinimalne has³o: {1}\nMaksymalne has³o: {2}\nHash: {3}\nRozmiar zadania: {4}", 
                    _minPass.Charset, _minPass.ToString(), _maxPass.ToString(), _hash, _size
                ); 
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="password"></param>
        /// <param name="size"></param>
        /// <param name="hash"></param>
        public PasswordTask(Password minPass, Password maxPass, ulong size, string hash)
        {
            //_timeout = new TimeSpan(0, 0, 0);
            _ExpireTime = DateTime.Now;
            _minPass = minPass;
            _maxPass = maxPass;
            _size = size;
            _hash = hash;
            _TaskId = _minPass.ToString().GetHashCode();
        }

        #endregion

        #region Methods ITask

        public ITaskResult Execute()
        {
            ITaskResult result = null;

            for (; _minPass <= _maxPass && !_stoped; _minPass++)
            {
                if (_minPass.Hash() == _hash)
                {
                    result = new PasswordTaskResult(_minPass.ToString());
                    break;
                }
            }
            return result;
        }

        public void Stop()
        {
            _stoped = true;
        }

        #endregion

        
    }
}
