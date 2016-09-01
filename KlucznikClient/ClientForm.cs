using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KlucznikClient
{
    public partial class ClientForm : Form
    {
        private ClientConfigurationForm configuration;
        private TaskClient client = null;

        public ClientForm()
        {
            InitializeComponent();
            configuration = new ClientConfigurationForm();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Uruchomiony";

            client = new TaskClient(configuration.Host, configuration.Port);
            client.ClientUpdate += new ClientUpdateEventHandler(client_ClientUpdate);
            client.StartAsync();

            startToolStripMenuItem.Enabled = false;
            //konfiguracjaToolStripMenuItem.Enabled = false;
        }

        void client_ClientUpdate(object sender, ClientUpdateEventArgs e)
        {
            toolStripStatusLabel.Text = e.Text;
            if (client != null && client.Task != null)
            {
                labelTaskInfo.Text = string.Format("Id zadania: {0}\nData wygaœniêcia: {1}\n{2}", 
                    client.TaskId, client.Task.ExpireTime, client.Task.Description);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client != null)
                client.Stop();
            client = null;
            startToolStripMenuItem.Enabled = true;
//            konfiguracjaToolStripMenuItem.Enabled = true;
            toolStripStatusLabel.Text = "Zatrzymany";
            
        }

        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configuration == null)
                configuration = new ClientConfigurationForm();
            else
                configuration.Visible = true;
        }
    }
}