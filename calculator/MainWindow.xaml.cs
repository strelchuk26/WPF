using System;
using System.Collections.Generic;
using System.Linq;
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

namespace calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public int FirstNumber { get; set; } = 0;
		public int SecondNumber { get; set; } = 0;
        public float Result { get; set; } = 0;
		public char Operation { get; set; }

        public MainWindow()
		{
			InitializeComponent();
		}

		private void CleanEntry_Click(object sender, RoutedEventArgs e)
		{
			FirstNumber = 0;
			SecondNumber = 0;
			textBox.Text = "0";
		}

		private void Clean_Click(object sender, RoutedEventArgs e)
		{
			FirstNumber = 0;
			SecondNumber = 0;
			textBox.Text = "0";
		}

		private void NumberClick(object sender, RoutedEventArgs e)
		{
			if (textBox.Text == "0" || textBox.Text == "+" || textBox.Text == "-" || textBox.Text == "*" || textBox.Text == "/")
				textBox.Text = "";
			Button button = sender as Button;
			textBox.Text += button.Content.ToString();
			SecondNumber = Int32.Parse(textBox.Text);
		}

		private void Plus_Click(object sender, RoutedEventArgs e)
		{
			FirstNumber = Int32.Parse(textBox.Text);
			Operation = '+';
			textBox.Text = Operation.ToString();
		}

		private void Minus_Click(object sender, RoutedEventArgs e)
		{
			FirstNumber = Int32.Parse(textBox.Text);
			Operation = '-';
			textBox.Text = Operation.ToString();
		}

		private void Star_Click(object sender, RoutedEventArgs e)
		{
			FirstNumber = Int32.Parse(textBox.Text);
			Operation = '*';
			textBox.Text = Operation.ToString();
		}

		private void Slash_Click(object sender, RoutedEventArgs e)
		{
			FirstNumber = Int32.Parse(textBox.Text);
			Operation = '/';
			textBox.Text = Operation.ToString();
		}

		private void Equals_Click(object sender, RoutedEventArgs e)
		{
			if (textBox.Text == "+" || textBox.Text == "-" || textBox.Text == "*" || textBox.Text == "/")
				return;

			SecondNumber = Int32.Parse(textBox.Text);

			switch (Operation)
			{
				case '+':
					Result = FirstNumber + SecondNumber;
					break;
				case '-':
					Result = FirstNumber - SecondNumber;
					break;
				case '*':
					Result = FirstNumber * SecondNumber;
					break;
				case '/':
					 Result = FirstNumber / SecondNumber;
					break;
				default:
					break;
			}
			textBox.Text = Result.ToString();
		}
	}
}
