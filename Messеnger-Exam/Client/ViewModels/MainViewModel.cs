using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using ClassLibrary.Models;
using Client.CustomControls;
using PropertyChanged;

namespace Client.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	internal class MainViewModel
	{
		private string remoteIP = "127.0.0.1";
		private short remotePort = 9999;
        public string CurrentMessage { get; set; }
		private Member Member;
		private ObservableCollection<ChatMember> chatMembers = new();
		public IEnumerable<ChatMember> ChatMembers => chatMembers;
        private ObservableCollection<ChatMessage> messages = new();
        public IEnumerable<ChatMessage> Messages => messages;
        public ICommand SendMessage { get; }

        public MainViewModel(Member member)
        {
			GetMemberData(member);
			ConnectToServer();
			SendMessage = new ViewModelCommand(ExecuteSendMessageCommand, CanExecuteSendMessageCommand);
        }

		private async void ConnectToServer()
		{
			if (Member.ClientData.Connected) return;

			await Member.ClientData.ConnectAsync(IPAddress.Parse(remoteIP), remotePort);
			SendRequest(new ClientCommand(RequestCommand.Join, Member.Username));
			ServerListen();
		}

		public void GetMemberData(Member member)
		{
			Member = new();
			Member.Username = member.Username;
			Member.Password = member.Password;
			Member.Email = member.Email;
			Member.ClientData = new TcpClient();
		}

		private void SendRequest(ClientCommand req)
		{
			NetworkStream ns = Member.ClientData.GetStream();

			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(ns, req);
			ns.Flush();
		}

		private async void ServerListen()
		{
			while (true)
			{
				ClientCommand cmd = await GetResponse();

				if (cmd.Command == RequestCommand.Message)
				{
					messages.Add(new ChatMessage()
					{
						Username = cmd.Username,
						Message = cmd.Message,
						Color = new SolidColorBrush(new Color { A = cmd.MessageColor.A, R = cmd.MessageColor.R, G = cmd.MessageColor.G, B = cmd.MessageColor.B })
					});
				}

				else if (cmd.Command == RequestCommand.GetMembers)
				{
					chatMembers.Clear();
					foreach (var name in cmd.MembersNames)
					{
						if (!chatMembers.Contains(new ChatMember() { Username = name }))
							chatMembers.Add(new ChatMember() { Username = name });
					}
				}
			}
		}

		private Task<ClientCommand> GetResponse()
		{
			return Task.Run(() =>
			{
				NetworkStream ns = Member.ClientData.GetStream();

				BinaryFormatter formatter = new BinaryFormatter();
				return (ClientCommand)formatter.Deserialize(ns);
			});
		}

		private bool CanExecuteSendMessageCommand(object arg)
		{
			bool isValid = true;
			if (string.IsNullOrWhiteSpace(CurrentMessage))
				isValid = false;
            return isValid;
		}

		private void ExecuteSendMessageCommand(object obj)
		{
			SendRequest(new ClientCommand(RequestCommand.Message) { Message = CurrentMessage, Username = Member.Username });
			CurrentMessage = "";
		}

		public void WindowClosed(object sender, CancelEventArgs e)
		{
			SendRequest(new ClientCommand(RequestCommand.Leave, Member.Username));
		}
	}
}
