using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TS3Client;
using TS3Client.Messages;
using TS3Client.Full;

namespace TS3ClientGUI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
            if (Properties.Settings.Default.autoconnect)
                Connect();
        }

        public void LoadSettings()
        {
            var settings = Properties.Settings.Default;
            this.ip.Text = settings.ip;
            this.port.Text = settings.port.ToString();
            this.nickname.Text = settings.nickname;
            this.password.Text = settings.password;
            this.chk_autoconnect.Checked = settings.autoconnect;
        }

        public void SaveSettings()
        {
            var settings = Properties.Settings.Default;
            settings.ip = this.ip.Text;
            settings.port = Convert.ToUInt16(this.port.Text);
            settings.nickname = this.nickname.Text;
            settings.password = this.password.Text;
            settings.autoconnect = this.chk_autoconnect.Checked;
            Properties.Settings.Default.Save();
        }

        public void Connect()
        {
            SaveSettings();
            this.btn_connect.Visible = false;
            this.btn_disconnect.Visible = true;
            this.txt_message.ReadOnly = false;
            this.btn_send.Enabled = true;
            Client.TS3Client.Connect(this);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void txt_message_TextChanged(object sender, EventArgs e)
        {
            this.btn_send.Enabled = true;
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            this.btn_disconnect.Visible = false;
            this.btn_connect.Visible = true;
            this.btn_send.Enabled = false;
            this.txt_message.ReadOnly = true;
            Client.TS3Client.client.Disconnect();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Client.TS3Client.SendMessage(this.txt_message.Text);
            this.txt_message.Clear();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Up))
            {
                this.txt_message.ClearUndo();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
