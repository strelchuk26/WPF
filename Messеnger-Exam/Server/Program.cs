using ClassLibrary.Models;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
	internal class Program
	{
		private const string localIP = "127.0.0.1";
		private const short localPort = 9999;

		static TcpListener server;

		static void Main(string[] args)
		{
			IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(localIP), localPort);

			server = new TcpListener(localEndPoint);
			server.Start();

			Chat chat = new();

			while (true) 
			{
				Member member = new();
				member.ClientData = server.AcceptTcpClient();

				ClientCommand req = GetClientRequest(member);
				member.Username = req.Username;

				if (req.Command == RequestCommand.Join)
				{
					chat.AddMember(member);
                    Console.WriteLine($"{req.Username} is joined to chat!");
                }
			}
		}

		private class Chat
		{
			List<Member> members = new(); 

			public void AddMember(Member member)
			{
				foreach (var m in members)
					SendMessage("Server", $"{member.Username} is joined to chat!", m, Color.FromArgb(255, 30, 217, 80));

				members.Add(member);

				foreach (var m in members)
					SendMembersList(m);

				Task.Run(() => ListenClient(member));
			}

			public void SendMessage(string username, string msg, Member reciever, Color color)
			{

				var cmd = new ClientCommand(RequestCommand.Message)
				{
					Username = username,
					Message = msg,
					MessageColor = color,
				};

				SendResponse(cmd, reciever);
			}

			public void SendMembersList(Member reciever)
			{
				var cmd = new ClientCommand(RequestCommand.GetMembers) { MembersNames = new() };

				foreach (var m in members)
					cmd.MembersNames.Add(m.Username);

				SendResponse(cmd, reciever);
			}

			public void SendResponse(ClientCommand cmd, Member client)
			{
				NetworkStream ns = client.ClientData.GetStream();

				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(ns, cmd);
				ns.Flush();
			}

			public void ListenClient(Member member)
			{
				bool isExit = false;
				while (!isExit)
				{
					ClientCommand req = GetClientRequest(member);

					switch (req.Command)
					{
						case RequestCommand.Leave:
							members.Remove(member);
							member.ClientData.Close();
							isExit = true;
							Console.WriteLine($"{req.Username} is leaved!");

							foreach (var m in members)
							{
								SendMessage("Server", $"{req.Username} is leaved!", m, Color.FromArgb(255, 240, 36, 94));
								SendMembersList(m);
							}
							break;
						case RequestCommand.Message:
							foreach (var m in members)
							{
								if (m.Username == req.Username)
									SendMessage(req.Username, req.Message, m, Color.FromArgb(255, 0, 153, 243));
								else
									SendMessage(req.Username, req.Message, m, Color.FromArgb(255, 170, 0 , 255));
							}
							break;
						case RequestCommand.GetMembers:
							foreach (var m in members)
								SendMembersList(m);
							break;
						default:
							break;
					}
				}
			}
		}

		private static ClientCommand GetClientRequest(Member member)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			return (ClientCommand)formatter.Deserialize(member.ClientData.GetStream());
		}
	}
}