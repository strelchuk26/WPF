using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary;
using Newtonsoft.Json;

namespace Server
{
	internal class Program
	{
		static IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
		static int port = 8888;

		static void Main(string[] args)
		{
			IPEndPoint localEndPoint = new IPEndPoint(iPAddress, port);
			IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

			TcpListener server = new TcpListener(localEndPoint);

			server.Start(10);
			while (true)
			{
				Console.WriteLine("waiting for order...");
				TcpClient client = server.AcceptTcpClient();

				BinaryFormatter serializer = new BinaryFormatter();
				var order = (Order)serializer.Deserialize(client.GetStream());

				Console.WriteLine($"{order.ClientFullName} {order.ClientPhoneNumber} {order.PizzaName} {order.PizzaCount}");
				var json = JsonConvert.SerializeObject(order);
				File.AppendAllText(@"orders.json", json);
                Console.WriteLine("Order added.");
            }
		}
	}
}