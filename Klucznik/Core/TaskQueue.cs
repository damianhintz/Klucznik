using System;
using System.Collections.Generic;
using System.Text;

namespace Klucznik.Core
{
    /// <summary>
    /// Kolejka aktywnych zadañ
    /// </summary>
    public class TaskQueue
    {
        #region Fields

        private Dictionary<int, ITask> _tasks;

        public int Count
        {
            get { return _tasks.Count; }
        }

        #endregion

        #region Constructors

        public TaskQueue()
        {
            _tasks = new Dictionary<int, ITask>();
        }

        #endregion

        #region Methods

        public ITask Peek()
        {
            ITask task = null;
            foreach (KeyValuePair<int, ITask> t in _tasks)
            {
                if (DateTime.Now > t.Value.ExpireTime)
                {
                    t.Value.ExpireTime = DateTime.Now;
                    task = t.Value;
                    break;
                }
            }
            return task;
        }

        public void Remove(ITask task)
        {
            _tasks.Remove(task.TaskId);
        }

        public bool Contains(ITask task)
        {
            return _tasks.ContainsKey(task.TaskId);
        }

        public void Push(ITask task)
        {
            _tasks.Add(task.TaskId, task);
        }

        #endregion
    }
}
