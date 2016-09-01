using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KlucznikClient
{
    public partial class ClientConfigurationForm : Form
    {
        private string _host;
        public string Host
        {
            get { return _host; }
        }

        private int _port;
        public int Port
        {
            get { return _port; }
        }

        public ClientConfigurationForm()
        {
            InitializeComponent();
            _host = textBoxHost.Text;
            _port = (int)numericUpDownPort.Value;
            toolTipPort.SetToolTip(numericUpDownPort, "<3333;33333>");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _host = textBoxHost.Text;
            _port = (int)numericUpDownPort.Value;
            this.Visible = false;
            
        }

        private void toolTipPort_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}