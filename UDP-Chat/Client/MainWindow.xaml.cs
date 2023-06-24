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
		UdpClient client = new UdpClient();
		private bool isListening = false;
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void Listen()
		{
			while (isListening)
			{
				var res = await client.ReceiveAsync();
				string msg = Encoding.UTF8.GetString(res.Buffer);
				msgList.Items.Add(msg);
			}
		}

		private void SendBtnClick(object sender, RoutedEventArgs e)
		{
			string text = msgTxtBox.Text;
			string name = userNameTxtBox.Text;
			if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(name) || text == "<join>" || text == "<leave>")
				return;
			SendMessage($"{name}: {text} \t{DateTime.Now.ToShortTimeString()}");
		}

		private void JoinBtnClick(object sender, RoutedEventArgs e)
		{
			SendMessage("<join>");
			isListening = true;
			Listen();
		}
		private void LeaveBtnClick(object sender, RoutedEventArgs e)
		{
			SendMessage("<leave>");
			isListening = false;
		}

		private void SendMessage(string text)
		{
			IPEndPoint serverIP = new(IPAddress.Parse(ipTxtBox.Text), int.Parse(portTxtBox.Text));

			byte[] data = Encoding.UTF8.GetBytes(text);
			client.Send(data, serverIP);
		}
	}
}
