using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Klucznik.Core;

namespace KlucznikClient
{
    public delegate void ClientUpdateEventHandler(object sender, ClientUpdateEventArgs e);

    /// <summary>
    /// Klient
    /// </summary>
    public class TaskClient
    {
        #region Fields

        #region Client

        private string _host = "127.0.0.1";
        private int _port = 12345;

        private TimeSpan timeout = new TimeSpan(0, 0, 0, 3);		//0 dni, 0 gdzin, 0 minut, 3 sekundy
        private UdpClient client = new UdpClient();
        private IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);

        private byte[] bytes;

        private bool received = false;
        private bool started = false;

        #endregion

        public event ClientUpdateEventHandler ClientUpdate;
        public delegate void StartAsyncCallback();
        private IAsyncResult ar;
        private StartAsyncCallback start;

        private ITask _task;
        public ITask Task
        {
            get { return _task; }
        }

        private int _id;
        public int TaskId
        {
            get { return _id; }
        }

        #endregion

        #region Constructor

        public TaskClient()
        {
        }

        public TaskClient(string host, int port)
        {
            _host = host;
            _port = port;
        }

        #endregion

        #region Methods

        protected virtual void OnClientUpdate(ClientUpdateEventArgs e)
        {
            if (ClientUpdate != null)
            {
                ClientUpdate(this, e);
            }
        }
        
        public void StartAsync()
        {
            start = new StartAsyncCallback(Start);
            ar = start.BeginInvoke(null, null);
        }

        private TaskMessage message;

        public void Start()
        {
            TimeSpan waitTime = new TimeSpan(0);
            int brakTime = 5;
            int stepTime = 1;
            int stopTime = 5;

            message = new TaskMessage();
            started = true;
            
            try
            {
                do
                {
                    OnClientUpdate(new ClientUpdateEventArgs("Wysyłanie wiadomości..."));
                    bytes = TaskMessage.Serialize(message);
                    client.Send(bytes, bytes.Length, _host, _port);

                    //Odbierz wiadomość
                    received = false;
                    OnClientUpdate(new ClientUpdateEventArgs("Czekam na odpowiedź..."));

                    IAsyncResult iresult = client.BeginReceive(new AsyncCallback(ReceiveCallback), null);
                    int index = WaitHandle.WaitAny(new WaitHandle[] { iresult.AsyncWaitHandle }, timeout, false);

                    if (index == WaitHandle.WaitTimeout)
                    {
                        OnClientUpdate(new ClientUpdateEventArgs("Serwer nie odpowiada, czekam " + stopTime + "s..."));
                        if (stopTime < 60)
                            stopTime += stepTime;
                        waitTime = new TimeSpan(0, 0, stopTime);
                        Thread.Sleep(waitTime);
                        //break;
                    }
                    else
                    {
                        stopTime = 5;
                        //Trzeba chwilę poczekać...
                        OnClientUpdate(new ClientUpdateEventArgs("Kończę odbieranie wiadomości..."));

                        DateTime startTime = DateTime.Now;
                        waitTime = new TimeSpan(0, 0, 1);  //1s
                        while (!received && DateTime.Now - startTime < waitTime)
                            continue;

                        if (!received)
                        {
                            OnClientUpdate(new ClientUpdateEventArgs("Nie udało się odebrać wiadomości :("));
                            break;
                        }

                        OnClientUpdate(new ClientUpdateEventArgs("Wiadomość odebrana"));

                        if (message.TaskId < 0)
                        {
                            if (brakTime < 60)
                                brakTime += stepTime;
                            OnClientUpdate(new ClientUpdateEventArgs("Chwilowo brak aktywnych zadań, czekam " + brakTime.ToString() + "s..."));
                            waitTime = new TimeSpan(0, 0, brakTime);
                            Thread.Sleep(waitTime);
                        }
                        else
                            if (message.Task != null)
                            {
                                brakTime = 5;
                                _task = message.Task;
                                _id = message.TaskId;
                                OnClientUpdate(new ClientUpdateEventArgs("Wykonuję zadanie..."));

                                ITaskResult result = _task.Execute();
                                message.Result = result;

                                OnClientUpdate(
                                    new ClientUpdateEventArgs("Zakończyłem szukanie")
                                );
                            }
                        
                    }
                
                } while (started);
            }
            catch (SocketException)
            {
                OnClientUpdate(new ClientUpdateEventArgs("Serwer nie odpowiada"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd aplikacji klienta: " + ex.ToString());
            }
            finally
            {
                started = false;
            }

        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            /*
             * Jeżeli zatrzymamy serwer w trakcie kończenia odierania to będzie wyjątek
            */
            try
            {
                bytes = client.EndReceive(ar, ref ep);
                message = TaskMessage.Deserialize(bytes);
                received = true;
            }
            catch (Exception)
            {
                received = false;
            }
        }

        public void Stop()
        {
            started = false;
            if (_task != null)
                _task.Stop();
            if (client != null)
                client.Close();
        }

        #endregion
    }
}