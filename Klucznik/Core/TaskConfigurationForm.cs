using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Klucznik.Core
{
    public class TaskConfigurationForm : Form
    {
        public virtual ITaskDispatcher GetDispatcher()
        {
            throw new Exception("you must impl. this");
        }

        public virtual TaskMode GetMode()
        {
            return TaskMode.SearchOne;
        }
    }
}
