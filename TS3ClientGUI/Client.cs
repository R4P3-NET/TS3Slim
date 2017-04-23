using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS3Client;
using TS3Client.Messages;
using TS3Client.Full;
using System.Windows.Forms;

namespace TS3ClientGUI
{
    class Client
    {
        public static Client TS3Client = new Client();

        ConnectionDataFull con;
        public Ts3FullClient client;
        MainWindow mainwindow;
        IdentityData id = Ts3Crypt.GenerateNewIdentity(8);

        public Client()
        {
            client = new Ts3FullClient(EventDispatchType.CurrentThread);
            client.OnConnected += Client_OnConnected;
            client.OnDisconnected += Client_OnDisconnected;
            client.OnErrorEvent += Client_OnErrorEvent;
            client.OnTextMessageReceived += Client_OnTextMessageReceived;
        }

        public void Connect(MainWindow sender)
        {
            mainwindow = sender;
            //var data = Ts3Crypt.LoadIdentity("MG8DAgeAAgEgAiEAqNonGuL0w/8kLlgLbl4UkH8DQQJ7fEu1tLt+mx1E+XkCIQDgQoIGcBVvAvNoiDT37iWbPQb2kYe0+VKLg67OH2eQQwIgTyijCKx7QB/xQSnIW5uIkVmcm3UU5P2YnobR9IEEYPg=", 64, 0);
            con = new ConnectionDataFull() {
                Hostname = Properties.Settings.Default.ip,
                Port = Properties.Settings.Default.port,
                Username = Properties.Settings.Default.nickname,
                Identity = id,
                Password = Properties.Settings.Default.password
            };
            client.Connect(con);
        }

        private void Client_OnDisconnected(object sender, DisconnectEventArgs e)
        {
            var client = (Ts3FullClient)sender;
            Console.WriteLine("Disconnected id {0}", client.ClientId);
        }

        private void Client_OnConnected(object sender, EventArgs e)
        {
            var client = (Ts3FullClient)sender;
            //mainwindow.ChatWidget.AppendText("Connected to "+Properties.Settings.Default.ip+":"+Properties.Settings.Default.port);
            var data = client.ClientInfo(client.ClientId);
            //client.Disconnect();
            //client.Connect(con);
        }

        private void Client_OnTextMessageReceived(object sender, IEnumerable<TextMessage> e)
        {
            foreach (var msg in e)
            {
                var source = (Ts3FullClient)sender;
                Console.WriteLine(msg.InvokerName + ": " + msg.Message);
                if (msg.Message.StartsWith("!nick "))
                    client.ChangeName(msg.Message.Replace("!nick ", ""));
                else if (msg.Message.StartsWith("!desc"))
                    client.ChangeDescription("we", (ClientData)sender);
                //client.SendMessage("Pong!", msg.TargetClientId);
                //TS3Client.Messages.ClientData.get(ClientId)
                else if (msg.Message == "Exit")
                {
                    var id = source.ClientId;
                    Console.WriteLine("Exiting... {0}", id);
                    client.Disconnect();
                    Console.WriteLine("Exited... {0}", id);
                }
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
