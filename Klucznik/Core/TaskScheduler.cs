using System;
using System.Collections.Generic;
using System.Text;
using Klucznik.Password;

namespace Klucznik.Core
{
    public class TaskScheduler
    {
        
        private Dictionary<int, TaskManager> _managers;

        public TaskScheduler()
        {
            _managers = new Dictionary<int, TaskManager>();
        }

        public void Add(TaskManager manager)
        {
            _managers.Add(manager.GetHashCode(), manager);
        }

        public void Remove(TaskManager manager)
        {
            _managers.Remove(manager.GetHashCode());
        }

        public void Clear()
        {
            _managers.Clear();
        }

        public TaskMessage Schedule(TaskMessage message)
        {
            TaskManager manager = null;
            if (message.Task != null && _managers.ContainsKey(message.TaskId))
            {
                manager = _managers[message.TaskId];
                manager.Dispatcher.Update(message.Task);
            }
            int min = int.MaxValue;
            foreach (KeyValuePair<int, TaskManager> tm in _managers)
            {
                if (tm.Value.State == TaskManagerState.Active && tm.Value.Dispatcher.ActiveTasks < min)
                {
                    min = tm.Value.Dispatcher.ActiveTasks;
                    manager = tm.Value;
                }
            }
            if (manager != null && manager.State == TaskManagerState.Active)
            {
                manager.Receive(message);
                return manager.Send();
            }
            else
                return new TaskMessage();
        }
    }
}
