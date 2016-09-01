using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Klucznik.Core
{
    public interface ITask : IInfo
    {
        int TaskId
        {
            get;
            //set;
        }

        DateTime ExpireTime
        {
            get;
            set;
        }

        ITaskResult Execute();

        void Stop();
    }
}
