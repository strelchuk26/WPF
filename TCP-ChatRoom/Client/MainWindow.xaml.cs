﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
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
using ClassLibrary;

namespace Client
{
	public partial class MainWindow : Window
	{
		private string remoteIP = "127.0.0.1";
		private short remotePort = 1234;

		TcpClient client = new TcpClient();

		public MainWindow()
		{
			InitializeComponent();
		}

		private async void ServerListen()
		{
			while (true)
			{
				ClientCommand cmd = await GetResponse();

				if (cmd.Command == RequestCommand.Message)
				{
					list.Items.Add($"{DateTime.Now.ToShortTimeString()} - {cmd.Nickname}: {cmd.Message}");
				}
			}
		}

		private async void JoinBtnClick(object sender, RoutedEventArgs e)
		{
			if (client.Connected) return;

			await client.ConnectAsync(IPAddress.Parse(remoteIP), remotePort);

			SendRequest(new ClientCommand(RequestCommand.Join, nameTxtBox.Text));
			ServerListen();
		}

		private void LeaveBtnClick(object sender, RoutedEventArgs e)
		{
			SendRequest(new ClientCommand(RequestCommand.Leave, nameTxtBox.Text));
		}

		private void SendRequest(ClientCommand req)
		{
			NetworkStream ns = client.GetStream();

			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(ns, req);
			ns.Flush();
		}
		private Task<ClientCommand> GetResponse()
		{
			return Task.Run(() =>
			{
				NetworkStream ns = client.GetStream();

				BinaryFormatter formatter = new BinaryFormatter();
				return (ClientCommand)formatter.Deserialize(ns);
			});
		}

		private void SendMsgBtnClick(object sender, RoutedEventArgs e)
		{
			SendRequest(new ClientCommand(RequestCommand.Message)
			{
				Message = msgTxtBox.Text,
				Nickname = nameTxtBox.Text
			});
		}
	}
}
