using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Klucznik.Core;
using Klucznik.Password;

namespace KlucznikServer
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ServerUpdateEventHandler(object sender, ServerUpdateEventArgs e);

    /// <summary>
    /// Serwer zada�
    /// </summary>
    /// <remarks>
    /// Serwer odbiera wiadomo�ci od klient�w i przekazuje je do zarz�dcy zada�. Wysy�a r�wnie�
    /// wiadomo�ci do klient�w z nowymi zadaniami.
    /// </remarks>
	public class TaskServer
    {
        
        #region Fields

        #region Server fields

        //private string _host = "127.0.0.1";
		private int _port = 12345;

		private UdpClient server;
		private IPEndPoint ep;

        #endregion

        #region Task fields

        private TaskScheduler _scheduler;
        private TaskManager _manager;

        #endregion

        #region Other fields

        private DateTime _StartTime;
        public DateTime StartTime
        {
            get { return _StartTime; }
        }

        private bool _started = false;
        public bool Started
        {
            get { return _started; }
        }

        /// <summary>
        /// Wska�nik do funkcji Start, kt�r� chcemy wywo�a� asynchronicznie.
        /// </summary>
        public delegate void StartAsyncCallback();
        private IAsyncResult ar;
        private StartAsyncCallback start;

        #endregion
        
        #endregion

        #region Constructors

        public TaskServer(int port)
        {
            _port = port;
            ep = new IPEndPoint(IPAddress.Any, _port);
        }

        public TaskServer(int port, TaskScheduler scheduler)
            : this(port)
        {
            _scheduler = scheduler;
        }

        #endregion

        #region Events

        public event ServerUpdateEventHandler ServerUpdate;

        protected virtual void OnServerUpdate(ServerUpdateEventArgs e)
        {
            if (ServerUpdate != null)
            {
                ServerUpdate(this, e);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        public void Register(TaskManager manager)
        {
            _manager = manager;
        }

        public void Stop()
        {
            _started = false;
            if (server != null)
            {
                server.Close();
                server = null;
            }
        }

        public void StartAsync()
        {
            start = new StartAsyncCallback(Start);
            ar = start.BeginInvoke(null, null);
        }

        /// <summary>
        /// Rozpoczynamy dzia�anie serwera
        /// </summary>
		public void Start()
		{
            _started = true;
            _StartTime = DateTime.Now;
            try
            {
                server = new UdpClient(_port);

                TaskMessage message = new TaskMessage();

                do
                {
                    byte[] bytes = null;
                    try
                    {
                        bytes = server.Receive(ref ep);
                    }
                    catch (SocketException)
                    {
                        //Spr�buje zrestartowa� serwer
                        if (_started)
                        {
                            server.Close();
                            server = null;
                        }
                    }

                    message = TaskMessage.Deserialize(bytes);
                    
                    OnServerUpdate(new ServerUpdateEventArgs("Czekam na wiadomo��..."));

                    message = _scheduler.Schedule(message);

                    OnServerUpdate(new ServerUpdateEventArgs("Wysy�am wiadomo��..."));

                    bytes = TaskMessage.Serialize(message);
                    server.Send(bytes, bytes.Length, ep);

                } while (_started);
            }
            catch (Exception ex)
            {
                if (_started)
                    MessageBox.Show("B��d serwera: " + ex.ToString());
                //else to jest zatrzymanie u�ytkownika
            }
			finally
			{
			    if(server != null && _started)
                    server.Close();
			}
            _started = false;
            DateTime endTime = DateTime.Now;
        }

        #endregion
    }
}