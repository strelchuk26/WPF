using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
	internal class Program
	{
		const int port = 3737;
		const string JOIN_CMD = "<join>";
		const string LEAVE_CMD = "<leave>";

		static void Main(string[] args)
		{
			UdpClient server = new UdpClient(port);
			HashSet<IPEndPoint> members = new();

			while (true)
			{
				IPEndPoint clientIP = null;
				byte[] data = server.Receive(ref clientIP);
				string message = Encoding.UTF8.GetString(data);

				switch (message)
				{
					case JOIN_CMD:
						if (members.Count < 10)
						{
							if (!members.Contains(clientIP))
							{
								members.Add(clientIP);
								Console.WriteLine($"{clientIP.Address}:{clientIP.Port} is joined.");
							}
							else
							{
                                Console.WriteLine("User is already connected.");
                            }
						}
						else
						{
							byte[] msg = Encoding.UTF8.GetBytes("Room is full.");
							server.Send(msg, clientIP);
						}
						break;
					case LEAVE_CMD:
						members.Remove(clientIP);
						Console.WriteLine($"{clientIP.Address}:{clientIP.Port} leaved.");
                        break;
					default:
						foreach (var m in members)
							server.Send(data, m);
						break;
				}
			}
		}
	}
}