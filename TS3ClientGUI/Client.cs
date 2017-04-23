using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS3Client;
using TS3Client.Commands;
using TS3Client.Full;
using TS3Client.Messages;
using TS3Client.Query;
using System.Windows.Forms;

namespace TS3ClientGUI
{
    class Client
    {
        public static Client TS3Client = new Client();

        ConnectionDataFull con;
        public Ts3FullClient client;
        MainWindow mainwindow;

        public Client()
        {
            client = new Ts3FullClient(EventDispatchType.AutoThreadPooled);
            client.QuitMessage = "Teamspeak 3 Slim";
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnErrorEvent += Client_OnErrorEvent;
            client.OnTextMessageReceived += Client_OnTextMessageReceived;
            client.OnClientEnterView += Client_OnClientEnterView;
            client.OnClientLeftView += Client_OnClientLeftView;
        }

        public event EventHandler<ClientEnterView> OnClientConnect;

        public void Connect(MainWindow sender)
        {
            mainwindow = sender;
            con = new ConnectionDataFull() {
                Hostname = Properties.Settings.Default.ip,
                Port = Properties.Settings.Default.port,
                Username = Properties.Settings.Default.nickname,
                Identity = Ts3Crypt.GenerateNewIdentity(8),
                Password = Properties.Settings.Default.password
            };
            client.Connect(con);
        }

        delegate void SetTextCallback(string text, int index, string author = null);
        delegate void AddTabCallback(string title);

        private void addChatTab(string title)
        {
            if (title == "") return;
            if (mainwindow.chatTabWidget.InvokeRequired)
            {
                AddTabCallback d = new AddTabCallback(addChatTab);
                mainwindow.chatTabWidget.Invoke(d, new object[] { title });
            }
            else
            {
                TabControl.TabPageCollection pages = mainwindow.chatTabWidget.TabPages;
                foreach (TabPage page in pages)
                    if (page.Text == title) return;
                mainwindow.chatTabWidget.TabPages.Add(title);
            }
        }

        private void ChatAppend(string text, int index, string author = null)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            RichTextBox tab;
            switch (index)
            {
                case 1:
                    tab = mainwindow.chatServerTab;
                    break;
                case 2:
                    tab = mainwindow.chatChannelTab;
                    break;
                case 0:
                    addChatTab(author);
                    for (int a = 0; a <= mainwindow.chatTabWidget.TabCount; a = a + 1)
                    {
                    //    mainwindow.chatTabWidget.
                    }
                    tab = mainwindow.chatServerTab;
                    break;
            }
            if (mainwindow.chatServerTab.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ChatAppend);
                mainwindow.chatServerTab.Invoke(d, new object[] { text, index, author });
            }
            else
            {
                string str = "[" + DateTime.Now.ToString() + "] " + text + "\n";
                mainwindow.chatServerTab.AppendText(str);
                if (Properties.Settings.Default.debug)
                    Console.WriteLine(str);
            }
        }

        public void SendMessage(string message)
        {
            MessageTarget target;
            switch (mainwindow.chatTabWidget.SelectedIndex)
            {
                case 1:
                    target = MessageTarget.Server; break;
                case 2:
                    target = MessageTarget.Channel; break;
                default:
                    target = MessageTarget.Private; break;
            }
        }

        private void Client_OnConnected(object sender, EventArgs e)
        {
            //var client = (Ts3FullClient)sender;
            //var data = client.ClientInfo(client.ClientId);
            ChatAppend("Connected to "+Properties.Settings.Default.ip+":"+Properties.Settings.Default.port, 0);
        }

        private void Client_OnDisconnected(object sender, DisconnectEventArgs e)
        {
            ChatAppend("Disconnected from " + Properties.Settings.Default.ip + ":" + Properties.Settings.Default.port, 0);
        }

        private void Client_OnClientEnterView(object sender, IEnumerable<ClientEnterView> eventArgs)
        {
            foreach (var user in eventArgs)
            {
                if (user.CountryCode != "")
                {
                    ChatAppend("\"" + user.NickName + "\" #"+user.ClientId+" connected from " + user.CountryCode + ".", 1);
                }
                else
                {
                    ChatAppend("\"" + user.NickName + "\" #" + user.ClientId + " connected.", 1);
                }
            }
        }

        private void Client_OnClientLeftView(object sender, IEnumerable<ClientLeftView> eventArgs)
        {
            foreach (var user in eventArgs)
            {
                ChatAppend("#" + user.ClientId + " disconnected.", 1);
            }
        }

        private void Client_OnTextMessageReceived(object sender, IEnumerable<TextMessage> e)
        {
            foreach (var msg in e)
            {
                var source = (Ts3FullClient)sender;
                ChatAppend(msg.InvokerName + ": " + msg.Message, 0, msg.InvokerName);
                if (msg.Message.StartsWith("!nick "))
                    client.ChangeName(msg.Message.Replace("!nick ", ""));
            }
        }

        private void Client_OnErrorEvent(object sender, CommandError e)
        {
            var client = (Ts3FullClient)sender;
            Console.WriteLine(e.ErrorFormat());
            if (!client.Connected)
            {
                client.Connect(con);
            }
        }
    }
}
