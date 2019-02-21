using CrossPlatformAESEncryption.Helper;
using GameInputCommandSystem.Views;
using System;
using System.Windows;

/**
 Copyright [2019] [Terence Doerksen]

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */
namespace GameInputCommandSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private MainController controller;
        private static GateKeeper server = new GateKeeper();
        private bool isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length < 6)
                System.Windows.MessageBox.Show("Please use a password at least 6 characters long.");
            else if (txtTarget.Text.Length <= 0)
            {
                System.Windows.MessageBox.Show("Ensure you set the target of the application you want to send commands to.");
            }
            else {
                int port = Int16.Parse(txtPort.Text);
                SetApplication(txtTarget.Text);
                SetPassword(txtPassword.Password);
                SetPort(port);
                ToggleServer();
                SaveSettings(txtTarget.Text, txtPassword.Password, port);
            }
        }

        private void LoadSettings()
        {
            txtTarget.Items.Add("Star Citizen");
            txtTarget.Text = Properties.Settings.Default.target;
            if (txtTarget.Text == "")
                txtTarget.Text = "Star Citizen";
            if (Properties.Settings.Default.password.Length > 5)
                txtPassword.Password = CryptoHelper.Decrypt(Properties.Settings.Default.password);
            int port = Properties.Settings.Default.port;
            if (port == 0)
                port = 8091;
            txtPort.Text = port.ToString();
        }

        private void SaveSettings(string target, string password, int port)
        {
            Properties.Settings.Default.target = target;
            String encrypted = CryptoHelper.Encrypt(password);
            Properties.Settings.Default.password = encrypted;
            Properties.Settings.Default.port = port;
            Properties.Settings.Default.Save();
        }

        private void ToggleServer()
        {
            if (isRunning)
            {
                server.Stop();
                isRunning = !isRunning;
                txtPassword.IsEnabled = true;
                txtPort.IsEnabled = true;
                txtTarget.IsEnabled = true;
            }
            else
            {
                isRunning = server.Start();
                txtPassword.IsEnabled = false;
                txtPort.IsEnabled = false;
                txtTarget.IsEnabled = false;
            }
            toggleText();
        }

        private void toggleText()
        {
            if (!isRunning)
                btnStart.Content = "Start";
            else
                btnStart.Content = "Stop";
        }

        internal void SetPort(int newPort)
        {
            server.Port = newPort;
        }

        internal void SetPassword(string text)
        {
            server.Password = text;
        }

        internal void SetApplication(string text)
        {
            server.Application = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            About window = new About();
            window.Show();
        }
    }
}
