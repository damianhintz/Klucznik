using System;
using System.Collections.Generic;
using System.Text;

namespace Klucznik.Core
{
    /// <summary>
    /// Informacje o zadaniu
    /// </summary>
    public interface ITaskInfo : IInfo
    {
        BigInteger AllTasks
        {
            get;
        }

        int ActiveTasks
        {
            get;
        }

        BigInteger DeadTasks
        {
            get;
        }

        TimeSpan Timeout
        {
            get;
            set;
        }

        ulong Size
        {
            get;
            set;
        }
    }
}
