using System;
using System.Collections.Generic;
using System.Text;

namespace Klucznik.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskDispatcher : ITaskInfo
    {
        TaskQueue Tasks
        {
            get;
        }

        ITask Dispatch();

        bool Update(ITask task);
    }
}
