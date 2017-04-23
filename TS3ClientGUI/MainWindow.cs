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
                Client.Connect(this);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.ip = this.ip.Text;
            settings.port = Convert.ToUInt16(this.port.Text);
            settings.nickname = this.nickname.Text;
            settings.password = this.password.Text;
            settings.autoconnect = this.chk_autoconnect.Checked;
            Properties.Settings.Default.Save();
            Client.Connect(this);
        }
    }
}
