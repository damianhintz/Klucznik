using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

/*
	Nazwa: Brute-force distributed password cracker message
	Wersja: 1.3
	Opis:
		Miêdzy serwerem i klientem bêd¹ przesy³anie wiadomoœci w postaci obiektu klasy Message
*/

namespace Klucznik.Core
{	
    /// <summary>
    /// Wiadomoœæ z zadaniem i/lub wynikiem przekazywana miêdzy klientem i serwerem.
    /// </summary>
	[Serializable]
	public class TaskMessage
	{
        public int TaskId = -1;
        public ITaskResult Result = null;
        public ITask Task = null;

        /// <summary>
        /// Zamieñ wiadomoœæ na tablicê bajtów.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
		public static byte[] Serialize(TaskMessage m)
		{
			byte[] buffer = null;
			MemoryStream stream = new MemoryStream(4096);
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				formatter.Serialize(stream, m);
				buffer = stream.ToArray();
			}
			catch(Exception e)
			{
                MessageBox.Show(e.ToString());
				buffer = null;
			}
			finally
			{
				stream.Close();
			}
			return buffer;
		}
		
        /// <summary>
        /// Zamieñ tablicê bajtów na obiekt z wiadomoœci¹.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
		public static TaskMessage Deserialize(byte[] buffer)
		{
			TaskMessage message = null;
			MemoryStream stream = new MemoryStream(buffer);
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				message = (TaskMessage)formatter.Deserialize(stream);
			}
			catch(Exception e)
			{
                MessageBox.Show(e.ToString());
				message = null;
			}
			finally
			{
				stream.Close();
			}
			return message;
		}
	}
}