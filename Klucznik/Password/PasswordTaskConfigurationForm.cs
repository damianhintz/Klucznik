using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Klucznik.Core;

namespace Klucznik.Password
{
    public partial class PasswordTaskConfigurationForm : TaskConfigurationForm
    {
        public ulong TaskSize = 100000;
        public PasswordCharset Charset;
        public Password MinPass;
        public Password MaxPass;
        public string Hash;
        public TimeSpan Timeout;
        public IHashAlgorithm HashAlgorithm;

        public PasswordTaskConfigurationForm()
        {            
            InitializeComponent();
            Charset = new PasswordCharset(textBoxCharset.Text);
            MinPass = new Password(textBoxMin.Text, Charset, HashAlgorithm);
            MaxPass = new Password(textBoxMax.Text, Charset, HashAlgorithm);
            Hash = "";
            HashAlgorithm = new MD5HashAlgorithm();

        }

        public override ITaskDispatcher GetDispatcher()
        {
            ITaskDispatcher dispatcher = new PasswordTaskDispatcher(Charset, MinPass, MaxPass, Hash, HashAlgorithm, Timeout, TaskSize);
            return dispatcher;
        }

        public override TaskMode GetMode()
        {
            return radioButtonAll.Checked ? TaskMode.SearchAll : TaskMode.SearchOne;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                MinPass = new Password(textBoxMin.Text, Charset, HashAlgorithm);
                MaxPass = new Password(textBoxMax.Text, Charset, HashAlgorithm);
                if (MinPass > MaxPass)
                    throw new Exception("Has³o minimalne nie mo¿e byæ wiêksze od maksymalnego");
                Hash = textBoxHash.Text;
                TaskSize = (ulong)numericUpDownSize.Value;
                Timeout = TimeSpan.Parse(maskedTextBoxTimeout.Text);

                this.Visible = false;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            string haslo = textBoxHash.Text;
            
            try
            {
                Password pass = new Password(haslo, Charset, HashAlgorithm);
                textBoxHash.Text = pass.Hash();
            }
            catch (Exception ex)
            {
                textBoxHash.Text = ex.Message;
            }
        }

        private void radioButtonMD5_Click(object sender, EventArgs e)
        {
            HashAlgorithm = new MD5HashAlgorithm();
        }

        private void radioButtonSHA1_Click(object sender, EventArgs e)
        {
            HashAlgorithm = new SHA1HashAlgorithm();
        }

        private void textBoxCharset_TextChanged(object sender, EventArgs e)
        {
            Charset = new PasswordCharset(textBoxCharset.Text);
        }

        private void radioButtonMD5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}