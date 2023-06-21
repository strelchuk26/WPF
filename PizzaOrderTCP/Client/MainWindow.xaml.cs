using System;
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
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OrderButtonClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(fullNameTxtBox.Text) ||
				string.IsNullOrWhiteSpace(phoneTxtBox.Text) ||
				string.IsNullOrWhiteSpace(addressTxtBox.Text) ||
				string.IsNullOrWhiteSpace(pizzaName.Text) ||
				string.IsNullOrWhiteSpace(pizzaCount.Text))
			{
				MessageBox.Show("Enter valid data!");
				return;
			}

			IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
			TcpClient client = new TcpClient();

			try
			{
				client.Connect(endPoint);
				Order order = new()
				{
					ClientFullName = fullNameTxtBox.Text,
					ClientPhoneNumber = phoneTxtBox.Text,
					ClientAddress = addressTxtBox.Text,
					PizzaName = pizzaName.Text,
					PizzaCount = int.Parse(pizzaCount.Text)
				};

				BinaryFormatter serializer = new BinaryFormatter();
				using (NetworkStream stream = client.GetStream())
				{
					serializer.Serialize(stream, order);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				client.Close();
			}
		}
	}
}
