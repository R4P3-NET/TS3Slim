namespace TS3ClientGUI
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lbl_ip = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.lbl_port = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.lbl_nickname = new System.Windows.Forms.Label();
            this.nickname = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.chk_autoconnect = new System.Windows.Forms.CheckBox();
            this.TreeView = new System.Windows.Forms.ListBox();
            this.ChatWidget = new System.Windows.Forms.RichTextBox();
            this.infoData = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(13, 13);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(20, 13);
            this.lbl_ip.TabIndex = 0;
            this.lbl_ip.Text = "IP:";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(54, 10);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(100, 20);
            this.ip.TabIndex = 1;
            this.ip.Text = "127.0.0.1";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(161, 13);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(29, 13);
            this.lbl_port.TabIndex = 2;
            this.lbl_port.Text = "Port:";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(202, 10);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(41, 20);
            this.port.TabIndex = 3;
            this.port.Text = "9987";
            // 
            // lbl_nickname
            // 
            this.lbl_nickname.AutoSize = true;
            this.lbl_nickname.Location = new System.Drawing.Point(249, 13);
            this.lbl_nickname.Name = "lbl_nickname";
            this.lbl_nickname.Size = new System.Drawing.Size(58, 13);
            this.lbl_nickname.TabIndex = 4;
            this.lbl_nickname.Text = "Nickname:";
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(310, 10);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(100, 20);
            this.nickname.TabIndex = 5;
            this.nickname.Text = "SlimTeamspeakUser";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(416, 13);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(56, 13);
            this.lbl_password.TabIndex = 6;
            this.lbl_password.Text = "Password:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(478, 10);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 7;
            this.password.Text = "123";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(706, 8);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 8;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // chk_autoconnect
            // 
            this.chk_autoconnect.AutoSize = true;
            this.chk_autoconnect.Location = new System.Drawing.Point(609, 12);
            this.chk_autoconnect.Name = "chk_autoconnect";
            this.chk_autoconnect.Size = new System.Drawing.Size(91, 17);
            this.chk_autoconnect.TabIndex = 9;
            this.chk_autoconnect.Text = "Auto Connect";
            this.chk_autoconnect.UseVisualStyleBackColor = true;
            this.chk_autoconnect.Visible = false;
            // 
            // TreeView
            // 
            this.TreeView.FormattingEnabled = true;
            this.TreeView.Location = new System.Drawing.Point(12, 37);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(361, 446);
            this.TreeView.TabIndex = 10;
            this.TreeView.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ChatWidget
            // 
            this.ChatWidget.Location = new System.Drawing.Point(12, 493);
            this.ChatWidget.Name = "ChatWidget";
            this.ChatWidget.ReadOnly = true;
            this.ChatWidget.Size = new System.Drawing.Size(769, 134);
            this.ChatWidget.TabIndex = 11;
            this.ChatWidget.Text = "";
            // 
            // infoData
            // 
            this.infoData.Location = new System.Drawing.Point(379, 37);
            this.infoData.Name = "infoData";
            this.infoData.ReadOnly = true;
            this.infoData.Size = new System.Drawing.Size(402, 450);
            this.infoData.TabIndex = 12;
            this.infoData.Text = "";
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(706, 633);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 13;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(12, 635);
            this.txt_message.Name = "txt_message";
            this.txt_message.ReadOnly = true;
            this.txt_message.Size = new System.Drawing.Size(688, 20);
            this.txt_message.TabIndex = 14;
            this.txt_message.TextChanged += new System.EventHandler(this.txt_message_TextChanged);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(706, 8);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_disconnect.TabIndex = 15;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Visible = false;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 658);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.infoData);
            this.Controls.Add(this.ChatWidget);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.chk_autoconnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.password);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.lbl_nickname);
            this.Controls.Add(this.port);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.lbl_ip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Teamspeak 3 Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label lbl_nickname;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.CheckBox chk_autoconnect;
        public System.Windows.Forms.ListBox TreeView;
        public System.Windows.Forms.RichTextBox ChatWidget;
        public System.Windows.Forms.RichTextBox infoData;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.Button btn_disconnect;
    }
}

