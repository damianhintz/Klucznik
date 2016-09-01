using System;
using System.Collections.Generic;
using System.Text;

namespace KlucznikClient
{
    public class ClientUpdateEventArgs : EventArgs
    {
        private string message;
        public string Text
        {
            get { return this.message; }
        }

		public ClientUpdateEventArgs()
		{
		}
		
		public ClientUpdateEventArgs(string message)
		{
            this.message = message;
		}

    }
}
