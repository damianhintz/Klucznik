using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Klucznik.Core;
using Klucznik.Password;

namespace KlucznikServer
{
    public partial class ServerForm : Form
    {
        private TaskScheduler scheduler = null;
        private TaskConfigurationForm configuration = null;
        private TaskServer server = null;
        
        private ListViewItem listItem;
        private ListViewItem.ListViewSubItem itemZadania;
        private ListViewItem.ListViewSubItem itemAktywne;
        private ListViewItem.ListViewSubItem itemWykonane;
        private ListViewItem.ListViewSubItem itemProcent;
        private ListViewItem.ListViewSubItem itemSzybkosc;
        private ListViewItem.ListViewSubItem itemStatus;
        private ListViewItem.ListViewSubItem itemMode;
	
        public ServerForm()
        {
            scheduler = new TaskScheduler();
            InitializeComponent();
        }

        private void Uruchom()
        {
            int port;
            try
            {
                if (server != null)
                    throw new Exception("Serwer ju¿ dzia³a");
                port = int.Parse(toolStripTextBoxPort.Text);
                server = new TaskServer(port, scheduler);
                server.ServerUpdate += new ServerUpdateEventHandler(s_ServerUpdate);
                server.StartAsync();

                //configurationToolStripMenuItem.Enabled = false;
                startToolStripMenuItem.Enabled = false;
                toolStripButtonUruchom.Enabled = false;
                toolStripStatusLabel.Text = "Uruchomiony";
            }
            catch(Exception ex)
            {
                toolStripStatusLabel.Text = "Zatrzymany";
                MessageBox.Show(ex.ToString());
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uruchom();
            
        }

        private void UpdateListView(string status)
        {
            TimeSpan elapsedTime;
            if (server != null)
                elapsedTime = (DateTime.Now - server.StartTime);
            else
                elapsedTime = new TimeSpan(0);
            foreach (ListViewItem li in listView.Items)
            {
                TaskManager manager = (li.Tag as TaskManager);
                li.SubItems[1].Text = (manager).Dispatcher.AllTasks.ToString();
                li.SubItems[2].Text = (manager).Dispatcher.ActiveTasks.ToString();
                li.SubItems[3].Text = (manager).Dispatcher.DeadTasks.ToString();
                
                if (manager.Dispatcher.AllTasks > 0)
                    li.SubItems[4].Text = 
                        (((manager).Dispatcher.DeadTasks * 100) / (manager).Dispatcher.AllTasks).ToString() + "%";
                if (elapsedTime.TotalMinutes > 1)
                    li.SubItems[5].Text = (manager.Dispatcher.DeadTasks / (ulong)elapsedTime.TotalMinutes).ToString() + "";
                //li.SubItems[6].Text = status;
                li.SubItems[6].Text = manager.State.ToString();
                //li.SubItems[7].Text = manager.Mode;
            }
        }

        void s_ServerUpdate(object sender, ServerUpdateEventArgs e)
        {
            TimeSpan elapsedTime = (DateTime.Now - server.StartTime);

            UpdateListView(e.Text);
            
            toolStripStatusLabel.Text = "Uruchomiony";
            //toolStripStatusLabelTime.Text = elapsedTime.ToString();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Stop();
                server = null;
            }

            toolStripStatusLabel.Text = "Zatrzymany";
            configurationToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            toolStripButtonUruchom.Enabled = true;
        }

        private void dodajZadanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuration = new PasswordTaskConfigurationForm();
            if(configuration.ShowDialog(this) != DialogResult.OK)
                return;

            if (server == null)
            {
                startToolStripMenuItem.Enabled = true;
                toolStripButtonUruchom.Enabled = true;
            }

            TaskManager manager = new TaskManager();
            manager.Dispatcher = configuration.GetDispatcher();
            manager.Mode = configuration.GetMode();

            scheduler.Add(manager);

            listItem = new ListViewItem(manager.GetHashCode().ToString());
            listItem.Tag = manager;

            itemZadania = new ListViewItem.ListViewSubItem(listItem, "0");
            itemAktywne = new ListViewItem.ListViewSubItem(listItem, "0");
            itemWykonane = new ListViewItem.ListViewSubItem(listItem, "0");
            itemProcent = new ListViewItem.ListViewSubItem(listItem, "0");
            itemSzybkosc = new ListViewItem.ListViewSubItem(listItem, "0");
            itemStatus = new ListViewItem.ListViewSubItem(listItem, "");
            itemMode = new ListViewItem.ListViewSubItem(listItem, manager.Mode.ToString());

            listItem.SubItems.Add(itemZadania);
            listItem.SubItems.Add(itemAktywne);
            listItem.SubItems.Add(itemWykonane);
            listItem.SubItems.Add(itemProcent);
            listItem.SubItems.Add(itemSzybkosc);
            listItem.SubItems.Add(itemStatus);
            listItem.SubItems.Add(itemMode);

            listView.Items.Add(listItem);
            configuration = null;
            UpdateListView("...");
        }

        private void usuñZadanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            scheduler.Clear();
            labelOpis.Text = "";

            if (configuration != null)
            {
                configuration.Dispose();
                configuration = null;
                listView.Items.Remove(listItem);
                listItem = null;
            }
        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonUruchom_Click(object sender, EventArgs e)
        {
            Uruchom();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                TaskManager manager = e.Item.Tag as TaskManager;
                labelOpis.Text = (manager).Dispatcher.ToString();
                labelOpis.Text += "--------------------------------------------------------------Wyniki--------------------------------------------------------------";
                foreach (ITaskResult result in manager.Results)
                {
                    labelOpis.Text += "\n" + result.Description;
                }
            }
        }

        private void labelOpis_Click(object sender, EventArgs e)
        {

        }

        private void usunZadanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                scheduler.Remove(item.Tag as TaskManager);
                listView.Items.Remove(item);
            }
        }

        private void zatrzymajZadanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                (item.Tag as TaskManager).State = TaskManagerState.Suspended;   
            }
            UpdateListView("");
        }

        private void uruchomZadanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                (item.Tag as TaskManager).State = TaskManagerState.Active;
            }
            UpdateListView("");
        }

    }
}