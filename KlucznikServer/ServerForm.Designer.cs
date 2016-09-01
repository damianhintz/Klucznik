namespace KlucznikServer
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajZadanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuñZadanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelhash = new System.Windows.Forms.Label();
            this.labelalfabet = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelPort = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonUruchom = new System.Windows.Forms.ToolStripButton();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderZadania = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAktywne = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWykonane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProcent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSzybkosc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uruchomZadanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatrzymajZadanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usunZadanieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelOpis = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.contextMenuStripListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(915, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.fileToolStripMenuItem.Text = "Serwer";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.startToolStripMenuItem.Text = "Uruchom";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.stopToolStripMenuItem.Text = "Zatrzymaj";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajZadanieToolStripMenuItem,
            this.usuñZadanieToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.configurationToolStripMenuItem.Text = "Zadania";
            // 
            // dodajZadanieToolStripMenuItem
            // 
            this.dodajZadanieToolStripMenuItem.Name = "dodajZadanieToolStripMenuItem";
            this.dodajZadanieToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.dodajZadanieToolStripMenuItem.Text = "Dodaj...";
            this.dodajZadanieToolStripMenuItem.Click += new System.EventHandler(this.dodajZadanieToolStripMenuItem_Click);
            // 
            // usuñZadanieToolStripMenuItem
            // 
            this.usuñZadanieToolStripMenuItem.Name = "usuñZadanieToolStripMenuItem";
            this.usuñZadanieToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.usuñZadanieToolStripMenuItem.Text = "Usuñ wszystkie";
            this.usuñZadanieToolStripMenuItem.Click += new System.EventHandler(this.usuñZadanieToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 516);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(915, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // labelhash
            // 
            this.labelhash.AutoSize = true;
            this.labelhash.Location = new System.Drawing.Point(221, 132);
            this.labelhash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelhash.Name = "labelhash";
            this.labelhash.Size = new System.Drawing.Size(0, 17);
            this.labelhash.TabIndex = 17;
            // 
            // labelalfabet
            // 
            this.labelalfabet.AutoSize = true;
            this.labelalfabet.Location = new System.Drawing.Point(221, 277);
            this.labelalfabet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelalfabet.Name = "labelalfabet";
            this.labelalfabet.Size = new System.Drawing.Size(0, 17);
            this.labelalfabet.TabIndex = 19;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelPort,
            this.toolStripTextBoxPort,
            this.toolStripButtonUruchom});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(915, 27);
            this.toolStrip.TabIndex = 25;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripLabelPort
            // 
            this.toolStripLabelPort.Name = "toolStripLabelPort";
            this.toolStripLabelPort.Size = new System.Drawing.Size(39, 24);
            this.toolStripLabelPort.Text = "Port:";
            // 
            // toolStripTextBoxPort
            // 
            this.toolStripTextBoxPort.MaxLength = 5;
            this.toolStripTextBoxPort.Name = "toolStripTextBoxPort";
            this.toolStripTextBoxPort.Size = new System.Drawing.Size(132, 27);
            this.toolStripTextBoxPort.Text = "12345";
            // 
            // toolStripButtonUruchom
            // 
            this.toolStripButtonUruchom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonUruchom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUruchom.Image")));
            this.toolStripButtonUruchom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUruchom.Name = "toolStripButtonUruchom";
            this.toolStripButtonUruchom.Size = new System.Drawing.Size(73, 24);
            this.toolStripButtonUruchom.Text = "Uruchom";
            this.toolStripButtonUruchom.Click += new System.EventHandler(this.toolStripButtonUruchom_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader,
            this.columnHeaderZadania,
            this.columnHeaderAktywne,
            this.columnHeaderWykonane,
            this.columnHeaderProcent,
            this.columnHeaderSzybkosc,
            this.columnHeaderStatus,
            this.columnHeaderMode});
            this.listView.ContextMenuStrip = this.contextMenuStripListView;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(911, 211);
            this.listView.TabIndex = 26;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "Id";
            // 
            // columnHeaderZadania
            // 
            this.columnHeaderZadania.Text = "Zadania";
            this.columnHeaderZadania.Width = 90;
            // 
            // columnHeaderAktywne
            // 
            this.columnHeaderAktywne.Text = "Aktywne";
            this.columnHeaderAktywne.Width = 65;
            // 
            // columnHeaderWykonane
            // 
            this.columnHeaderWykonane.Text = "Wykonane";
            this.columnHeaderWykonane.Width = 74;
            // 
            // columnHeaderProcent
            // 
            this.columnHeaderProcent.Text = "Procent[%]";
            this.columnHeaderProcent.Width = 81;
            // 
            // columnHeaderSzybkosc
            // 
            this.columnHeaderSzybkosc.Text = "Szybkoœæ[zadañ/m]";
            this.columnHeaderSzybkosc.Width = 118;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 97;
            // 
            // columnHeaderMode
            // 
            this.columnHeaderMode.Text = "Tryb";
            this.columnHeaderMode.Width = 79;
            // 
            // contextMenuStripListView
            // 
            this.contextMenuStripListView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uruchomZadanieToolStripMenuItem,
            this.zatrzymajZadanieToolStripMenuItem,
            this.usunZadanieToolStripMenuItem});
            this.contextMenuStripListView.Name = "contextMenuStripListView";
            this.contextMenuStripListView.Size = new System.Drawing.Size(154, 82);
            // 
            // uruchomZadanieToolStripMenuItem
            // 
            this.uruchomZadanieToolStripMenuItem.Name = "uruchomZadanieToolStripMenuItem";
            this.uruchomZadanieToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.uruchomZadanieToolStripMenuItem.Text = "Aktywuj";
            this.uruchomZadanieToolStripMenuItem.Click += new System.EventHandler(this.uruchomZadanieToolStripMenuItem_Click);
            // 
            // zatrzymajZadanieToolStripMenuItem
            // 
            this.zatrzymajZadanieToolStripMenuItem.Name = "zatrzymajZadanieToolStripMenuItem";
            this.zatrzymajZadanieToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.zatrzymajZadanieToolStripMenuItem.Text = "Wstrzymaj";
            this.zatrzymajZadanieToolStripMenuItem.Click += new System.EventHandler(this.zatrzymajZadanieToolStripMenuItem_Click);
            // 
            // usunZadanieToolStripMenuItem
            // 
            this.usunZadanieToolStripMenuItem.Name = "usunZadanieToolStripMenuItem";
            this.usunZadanieToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.usunZadanieToolStripMenuItem.Text = "Usuñ";
            this.usunZadanieToolStripMenuItem.Click += new System.EventHandler(this.usunZadanieToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelOpis);
            this.splitContainer1.Size = new System.Drawing.Size(915, 461);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 27;
            // 
            // labelOpis
            // 
            this.labelOpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelOpis.Location = new System.Drawing.Point(0, 0);
            this.labelOpis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(911, 237);
            this.labelOpis.TabIndex = 0;
            this.labelOpis.Click += new System.EventHandler(this.labelOpis_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.labelalfabet);
            this.Controls.Add(this.labelhash);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ServerForm";
            this.Text = "Klucznik Server v1.0";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStripListView.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelhash;
        private System.Windows.Forms.Label labelalfabet;
        private System.Windows.Forms.ToolStripMenuItem dodajZadanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuñZadanieToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPort;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPort;
        private System.Windows.Forms.ToolStripButton toolStripButtonUruchom;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderZadania;
        private System.Windows.Forms.ColumnHeader columnHeaderAktywne;
        private System.Windows.Forms.ColumnHeader columnHeaderWykonane;
        private System.Windows.Forms.ColumnHeader columnHeaderProcent;
        private System.Windows.Forms.ColumnHeader columnHeaderSzybkosc;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem usunZadanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatrzymajZadanieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uruchomZadanieToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderMode;
    }
}

