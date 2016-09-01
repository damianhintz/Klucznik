using System;
using System.Collections.Generic;
using System.Text;
using Klucznik.Core;

namespace Klucznik.Password
{
    /// <summary>
    /// Klasa wybieraj¹ca kolejne zadania do wykonania
    /// </summary>
    public class PasswordTaskDispatcher : ITaskDispatcher
    {
        #region Fields

        private TaskQueue _tasks = new TaskQueue();
        public TaskQueue Tasks
        {
            get { return _tasks; }
        }

        #region ITaskInfo

        public BigInteger AllTasks
        {
            get
            {
                BigInteger b = BigInteger.Complexity(_charset.Length, _min.Length, _maxPass.Length) / _size;
                return b + 1;
            }
        }

        public int ActiveTasks
        {
            get { return _tasks.Count; }
        }

        private BigInteger _deadTasks = 0;
        public BigInteger DeadTasks
        {
            get { return _deadTasks; }
        }

        private ulong _size;
        public ulong Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private TimeSpan _timeout;
        public TimeSpan Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        #endregion

        private PasswordTaskData _data;

        private PasswordCharset _charset;
        private string _hash;
        private IHashAlgorithm _hashAlgorithm;

        private Password _minPass;
        private Password _maxPass;
        private Password _min;

        private bool isMax = false;

        #endregion

        #region Constructor

        public PasswordTaskDispatcher(PasswordTaskData data)
        {
            _data = data;
        }

        public PasswordTaskDispatcher(PasswordTaskData data, TimeSpan timeout, ulong size)
            : this(data)
        {
            _timeout = timeout;
            _size = size;
        }


        public PasswordTaskDispatcher(PasswordCharset charset, Password minPass, Password maxPass, string hash, IHashAlgorithm iha, TimeSpan timeout, ulong size)
        {
            _data = new PasswordTaskData(charset, minPass, maxPass, hash, iha);
            _charset = charset;
            _minPass = minPass;
            _maxPass = maxPass;
            _hash = hash;
            _hashAlgorithm = iha;
            _timeout = timeout;
            _size = size;
            _min = new Password(_minPass.ToString(), _charset, _hashAlgorithm);
        }

        #endregion 

        #region Methods

        #region ITaskDispatcher

        public bool Update(ITask task)
        {
            if (_tasks.Contains(task))
            {
                _deadTasks++;
                _tasks.Remove(task);
                return true;
            }
            else
                return false;
        }

        public ITask Dispatch()
        {
            ITask task = _tasks.Peek();

            if (task != null && task.ExpireTime < DateTime.Now)
                task = null;

            if (task == null && isMax == false)
            {
                //Nie ma starych zadañ, wygeneruj nowe
                string minp = _minPass.ToString();
                

                _minPass.Next(_size, true);
                if (_minPass >= _maxPass)
                {
                    //To ju¿ jest ostatnie zadanie jakie mo¿emy wygenerowaæ
                    _minPass = new Password(_maxPass.ToString(), _charset, _hashAlgorithm);
                    isMax = true;
                }

                string maxp = _minPass.ToString();
                task = new PasswordTask(new Password(minp, _charset, _hashAlgorithm), new Password(maxp, _charset, _hashAlgorithm), _size, _hash);
                task.ExpireTime = DateTime.Now + _timeout;

                _tasks.Push(task);
                _minPass++;
            }
            return task;
        }

        #endregion

        #region ITaskInfo

        public string Description
        {
            get
            {
                return string.Format("Charset: {0}\nMinPass: {1}\n",
                _charset.Charset, _minPass.ToString()); ;
            }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("Zbiór znaków: {0}\nPocz¹tkowe has³o: {1}\nKoñcowe has³o: {2}\nHash: {3}\nAlgorytm: {4}\nRozmiar zadania klienta: {5}\nTimeout: {6}\n", 
                _charset.Charset, _min.ToString(), _maxPass.ToString(), _hash, _hashAlgorithm.ToString(), _size, _timeout);
        }

        #endregion
    }
}
