using System;
using System.Collections.Generic;
using System.Text;
using Klucznik.Password;

namespace Klucznik.Core
{
    /// <summary>
    /// Zarz¹dca zadañ
    /// </summary>
    public class TaskManager
    {
        #region Fields

        private TaskManagerState _state;
        public TaskManagerState State
        {
            get { return _state; }
            set 
            {
                if(_state != TaskManagerState.Completed)
                    _state = value; 
            }
        }

        private TaskMode _mode;
        public TaskMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        private TaskResultCollection _results;
        public TaskResultCollection Results
        {
            get { return _results; }
        }

        private ITaskResult _result = null;

        private ITaskDispatcher _dispatcher;
        public ITaskDispatcher Dispatcher
        {
            get { return _dispatcher; }
            set { _dispatcher = value; }
        }

        #endregion

        #region Constructors

        public TaskManager()
        {
            _state = TaskManagerState.Suspended;
            _mode = TaskMode.SearchOne;
            _results = new TaskResultCollection();   
        }

        public TaskManager(ITaskDispatcher dispatcher)
            : this()
        {
            _dispatcher = dispatcher;
        }

        public TaskManager(ITaskDispatcher dispatcher, TaskMode mode)
            : this(dispatcher)
        {
            _mode = mode;
        }

        #endregion

        #region Methods

        public void Receive(TaskMessage message)
        {
            if (message != null && message.Task != null)
            {
                _dispatcher.Update(message.Task);

                if (message.Result != null)
                {
                    _result = message.Result;
                    _results.Add(_result);
                    if (_mode == TaskMode.SearchOne)
                        _state = TaskManagerState.Completed;
                }
            }
        }

        public TaskMessage Send()
        {
            TaskMessage message = new TaskMessage();
            ITask task = _dispatcher.Dispatch();
            if (task == null && _dispatcher.ActiveTasks == 0 && _mode == TaskMode.SearchAll)
                _state = TaskManagerState.Completed;
            message.Task = task;
            if (_result != null && _mode == TaskMode.SearchOne)
            {
                message.Result = _result;
            }
            message.TaskId = this.GetHashCode();
            return message;
        }

        #endregion

    }
}
