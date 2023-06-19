using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
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
		UdpClient client = new();
		public MainWindow()
		{
			InitializeComponent();
			Listen();
		}

		private async void Listen()
		{
			SendMessage("client connected");
			while (true)
			{
				var res = await client.ReceiveAsync();
				string msg = Encoding.UTF8.GetString(res.Buffer);
				msgHistoryListBox.Items.Add($"Server: {msg}");
			}
		}

		private void SendMessageBtnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(msgTextBox.Text) ||
				string.IsNullOrWhiteSpace(ipTxtBox.Text) ||
				string.IsNullOrWhiteSpace(portTxtBox.Text))
				return;

			string message = msgTextBox.Text;

			SendMessage(message);
			msgHistoryListBox.Items.Add($"Me: {message}");
		}

		private async void SendMessage(string message)
		{
			try
			{
				IPEndPoint serverEndpoint = new(IPAddress.Parse(ipTxtBox.Text), int.Parse(portTxtBox.Text));
				byte[] data = Encoding.UTF8.GetBytes(message);
				await client.SendAsync(data, data.Length, serverEndpoint);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
