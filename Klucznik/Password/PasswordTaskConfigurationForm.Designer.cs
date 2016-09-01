using Klucznik.Core;
using Klucznik.Password;

namespace Klucznik.Password
{
    partial class PasswordTaskConfigurationForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxAlgorytm = new System.Windows.Forms.GroupBox();
            this.radioButtonSHA1 = new System.Windows.Forms.RadioButton();
            this.radioButtonMD5 = new System.Windows.Forms.RadioButton();
            this.textBoxHash = new System.Windows.Forms.TextBox();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.textBoxCharset = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.maskedTextBoxTimeout = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonOne = new System.Windows.Forms.RadioButton();
            this.groupBoxAlgorytm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.groupBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(441, 170);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBoxAlgorytm
            // 
            this.groupBoxAlgorytm.Controls.Add(this.radioButtonSHA1);
            this.groupBoxAlgorytm.Controls.Add(this.radioButtonMD5);
            this.groupBoxAlgorytm.Location = new System.Drawing.Point(15, 123);
            this.groupBoxAlgorytm.Name = "groupBoxAlgorytm";
            this.groupBoxAlgorytm.Size = new System.Drawing.Size(234, 41);
            this.groupBoxAlgorytm.TabIndex = 1;
            this.groupBoxAlgorytm.TabStop = false;
            this.groupBoxAlgorytm.Text = "Wybierz algorytm";
            // 
            // radioButtonSHA1
            // 
            this.radioButtonSHA1.AutoSize = true;
            this.radioButtonSHA1.Location = new System.Drawing.Point(140, 15);
            this.radioButtonSHA1.Name = "radioButtonSHA1";
            this.radioButtonSHA1.Size = new System.Drawing.Size(53, 17);
            this.radioButtonSHA1.TabIndex = 1;
            this.radioButtonSHA1.Text = "SHA1";
            this.radioButtonSHA1.UseVisualStyleBackColor = true;
            this.radioButtonSHA1.Click += new System.EventHandler(this.radioButtonSHA1_Click);
            // 
            // radioButtonMD5
            // 
            this.radioButtonMD5.AutoSize = true;
            this.radioButtonMD5.Checked = true;
            this.radioButtonMD5.Location = new System.Drawing.Point(36, 15);
            this.radioButtonMD5.Name = "radioButtonMD5";
            this.radioButtonMD5.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMD5.TabIndex = 0;
            this.radioButtonMD5.TabStop = true;
            this.radioButtonMD5.Text = "MD5";
            this.radioButtonMD5.UseVisualStyleBackColor = true;
            this.radioButtonMD5.Click += new System.EventHandler(this.radioButtonMD5_Click);
            this.radioButtonMD5.CheckedChanged += new System.EventHandler(this.radioButtonMD5_CheckedChanged);
            // 
            // textBoxHash
            // 
            this.textBoxHash.Location = new System.Drawing.Point(129, 38);
            this.textBoxHash.MaxLength = 256;
            this.textBoxHash.Name = "textBoxHash";
            this.textBoxHash.Size = new System.Drawing.Size(387, 20);
            this.textBoxHash.TabIndex = 2;
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(129, 65);
            this.textBoxMin.MaxLength = 128;
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(120, 20);
            this.textBoxMin.TabIndex = 5;
            this.textBoxMin.Text = "a";
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(396, 65);
            this.textBoxMax.MaxLength = 128;
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(120, 20);
            this.textBoxMax.TabIndex = 6;
            this.textBoxMax.Text = "zzzzzz";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "asdf";
            this.notifyIcon1.BalloonTipTitle = "jhgjgjhg";
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hash:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Minimalne has³o:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Maksymalne has³o:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rozmiar zadania:";
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(129, 95);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSize.TabIndex = 15;
            this.numericUpDownSize.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // textBoxCharset
            // 
            this.textBoxCharset.Location = new System.Drawing.Point(129, 9);
            this.textBoxCharset.MaxLength = 256;
            this.textBoxCharset.Name = "textBoxCharset";
            this.textBoxCharset.Size = new System.Drawing.Size(387, 20);
            this.textBoxCharset.TabIndex = 16;
            this.textBoxCharset.Text = "abcdefghijklmnopqrstuvwxyz";
            this.textBoxCharset.TextChanged += new System.EventHandler(this.textBoxCharset_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Zbiór znaków:";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(15, 170);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(74, 23);
            this.buttonTest.TabIndex = 21;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // maskedTextBoxTimeout
            // 
            this.maskedTextBoxTimeout.Location = new System.Drawing.Point(396, 95);
            this.maskedTextBoxTimeout.Mask = "00:00:00";
            this.maskedTextBoxTimeout.Name = "maskedTextBoxTimeout";
            this.maskedTextBoxTimeout.Size = new System.Drawing.Size(120, 20);
            this.maskedTextBoxTimeout.TabIndex = 22;
            this.maskedTextBoxTimeout.Text = "000300";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Timeout(hh:mm:ss):";
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButtonAll);
            this.groupBoxMode.Controls.Add(this.radioButtonOne);
            this.groupBoxMode.Location = new System.Drawing.Point(270, 121);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(246, 43);
            this.groupBoxMode.TabIndex = 24;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Tryb wyszukiwania";
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(126, 17);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(73, 17);
            this.radioButtonAll.TabIndex = 1;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Wszystkie";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonOne
            // 
            this.radioButtonOne.AutoSize = true;
            this.radioButtonOne.Checked = true;
            this.radioButtonOne.Location = new System.Drawing.Point(11, 19);
            this.radioButtonOne.Name = "radioButtonOne";
            this.radioButtonOne.Size = new System.Drawing.Size(80, 17);
            this.radioButtonOne.TabIndex = 0;
            this.radioButtonOne.TabStop = true;
            this.radioButtonOne.Text = "Tylko jeden";
            this.radioButtonOne.UseVisualStyleBackColor = true;
            // 
            // PasswordTaskConfigurationForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 200);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maskedTextBoxTimeout);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCharset);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.textBoxMin);
            this.Controls.Add(this.textBoxHash);
            this.Controls.Add(this.groupBoxAlgorytm);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PasswordTaskConfigurationForm";
            this.ShowInTaskbar = false;
            this.Text = "Dodaj zadanie poszukiwania has³a";
            this.groupBoxAlgorytm.ResumeLayout(false);
            this.groupBoxAlgorytm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBoxAlgorytm;
        private System.Windows.Forms.RadioButton radioButtonSHA1;
        private System.Windows.Forms.RadioButton radioButtonMD5;
        private System.Windows.Forms.TextBox textBoxHash;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.TextBox textBoxCharset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTimeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.RadioButton radioButtonOne;
        private System.Windows.Forms.RadioButton radioButtonAll;
    }
}