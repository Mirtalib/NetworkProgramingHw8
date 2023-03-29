using Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    public partial class MainWindow : Window
    {

        TcpClient client;
        XOGameMenecer? gameMenecer;
        public MainWindow()
        {
            InitializeComponent();
            client = new TcpClient("127.0.0.1", 2702);

        }



        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxRoomName.Text.Length != 4)
            {
                MessageBox.Show("Wrong Room Name");
                return;
            }

            var serverStream = client.GetStream();

            var binaryRead = new BinaryReader(serverStream);
            var binaryWrite = new BinaryWriter(serverStream);
            gameMenecer = new();
            gameMenecer.roomPassword = Convert.ToInt32(txtboxRoomName.Text);

            var jsonStr = JsonSerializer.Serialize(gameMenecer);
            binaryWrite.Write(jsonStr);

            var messageBoxResult= MessageBox.Show("Waiting", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (messageBoxResult == MessageBoxResult.Cancel)
                return;

            var serverResult = binaryRead.ReadString();

            /// gameMenecer = JsonSerializer.Deserialize<XOGameMenecer>(serverResult);

            if (serverResult == "Yes")
            {
                MessageBox.Show("Connect");
            }
        }
    }
}
