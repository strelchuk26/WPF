using Markov;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace KeyboardTrainer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Random random = new Random();
        public int MistakesCount { get; set; }
        public DateTime StartTime { get; set; }
        public DispatcherTimer Timer { get; set; }

        public MainWindow()
		{
			InitializeComponent();
			textBox.IsEnabled = false;
			Timer = new DispatcherTimer();
			Timer.Interval = TimeSpan.FromSeconds(1);
			Timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			TimeSpan elapsedTime = DateTime.Now - StartTime;
			timerText.Content = elapsedTime.ToString(@"ss");
		}

		private void StartBtnClick(object sender, RoutedEventArgs e)
		{
			string[] words = File.ReadAllLines("words.txt");
			StartTime = DateTime.Now;
			Timer.Start();

			textBlock.Text = "";

			switch (slider.Value)
			{
				case 1:
					for (int i = 0; i < 5; i++)
						textBlock.Text += words[random.Next(words.Length)] + " ";
					break;
				case 2:
					for (int i = 0; i < 10; i++)
						textBlock.Text += words[random.Next(words.Length)] + " ";
					break;
				case 3:
					for (int i = 0; i < 20; i++)
						textBlock.Text += words[random.Next(words.Length)] + " ";
					break;
				default:
					break;
			}

			textBox.IsEnabled = true;
		}

		private void textBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			var text = textBlock.Text;
			var writedText = textBox.Text;

			if (writedText.Length == text.Length - 1)
			{
				Timer.Stop();
				textBlock.Text = "";
				textBox.Text = "";
				textBox.IsEnabled = false;
				MessageBox.Show($"Time: {DateTime.Now.Second - StartTime.Second}s.\n" +
								$"Mistakes: {MistakesCount}\n");
			}

			for (int i = 0; i < writedText.Length; i++)
			{
				if (writedText[i] != text[i])
				{
					//progressBar.Value = text.Length / (text.Length / 100);
					textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
					textBox.Select(textBox.Text.Length, 0);
					MistakesCount++;
					mistakesCountLabel.Content = MistakesCount.ToString();
				}
			}
		}
	}
}
