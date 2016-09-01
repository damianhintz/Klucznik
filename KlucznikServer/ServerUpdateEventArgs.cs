using System;
using System.Net;

namespace KlucznikServer
{
	public class ServerUpdateEventArgs : EventArgs
	{
		private string message;
        public string Text
        {
            get { return this.message; }
        }

		public ServerUpdateEventArgs()
		{
		}
		
		public ServerUpdateEventArgs(string message)
		{
            this.message = message;
		}
	}
}