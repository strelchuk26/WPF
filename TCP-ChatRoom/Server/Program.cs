using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary;

namespace Server
{
	class Program
	{
		private const string localIP = "127.0.0.1";
		private const short localPort = 1234;

		static TcpListener server;

		static void Main(string[] args)
		{
			IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(localIP), localPort);

			server = new TcpListener(localEndPoint);
			server.Start();

			Chat chat = new Chat();

			while (true)
			{
				TcpClient client = server.AcceptTcpClient();

				ClientCommand req = GetClientRequest(client);

				if (req.Command == RequestCommand.Join)
				{
					chat.AddMember(client, req.Nickname);
                }
			}
		}

		static ClientCommand GetClientRequest(TcpClient client)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			return (ClientCommand)formatter.Deserialize(client.GetStream());
		}
	}

	class Chat
	{
		List<TcpClient> members = new List<TcpClient>();
		private const int maxMembers = 10;

		public void AddMember(TcpClient client, string name)
		{
			if (members.Count < maxMembers)
			{
				Console.WriteLine($"{name} joined to chat!");
				members.Add(client);
				Task.Run(() => ListenClient(client));
			}
			else
			{
				SendMessage("Server", $"Room is full!", client);
			}
		}

		public void ListenClient(TcpClient client)
		{
			bool isExit = false;
			while (!isExit)
			{
				ClientCommand req = GetClientRequest(client);

				switch (req.Command)
				{
					case RequestCommand.Leave:
						members.Remove(client);
						client.Close();
						isExit = true;
                        Console.WriteLine($"{req.Nickname} is leaved.");
						foreach (var m in members)
						{
							SendMessage($"Server", $"{req.Nickname} is leaved.", m);
						}
                        break;
					case RequestCommand.Message:
                        Console.WriteLine($"{DateTime.Now.ToShortTimeString()} {req.Nickname}: {req.Message}");
                        foreach (var m in members)
						{
							SendMessage(req.Nickname, req.Message, m);
						}
						break;
					default:
						break;
				}
			}
		}

		void SendMessage(string name, string msg, TcpClient reciever)
		{
			var cmd = new ClientCommand(RequestCommand.Message)
			{
				Message = msg,
				Nickname = name
			};
			SendResponse(cmd, reciever);
		}
		private void SendResponse(ClientCommand cmd, TcpClient client)
		{
			NetworkStream ns = client.GetStream();

			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(ns, cmd);
			ns.Flush();
		}
		static ClientCommand GetClientRequest(TcpClient client)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			return (ClientCommand)formatter.Deserialize(client.GetStream());
		}
	}
}