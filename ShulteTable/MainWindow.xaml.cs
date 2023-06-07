using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ShulteTable
{
	public partial class MainWindow : Window
	{
		Random random = new Random();
		private int index = 1;
		private const int buttonsCount = 48;
		private DispatcherTimer gameTimer;
		private int gameTime;

		public MainWindow()
		{
			InitializeComponent();
			FillButtons();
			StartTimer();
		}

		private void StartTimer()
		{
			gameTime = 0;
			gameTimer = new DispatcherTimer();
			gameTimer.Tick += new EventHandler(timer_Tick);
			gameTimer.Interval = new TimeSpan(0, 0, 1);
			gameTimer.Start();
		}

		private void timer_Tick(object? sender, EventArgs e) => gameTime++;

		public static void Shuffle<T>(IList<T> values)
		{
			for (int i = values.Count - 1; i > 0; i--)
			{
				Random random = new Random();
				int k = random.Next(i + 1);
				T value = values[k];
				values[k] = values[i];
				values[i] = value;
			}
		}
		public List<Border> FindAllButtons(DependencyObject parent)
		{
			List<Border> buttons = new List<Border>();

			if (parent is Border button)
			{
				buttons.Add(button);
			}
			else
			{
				int childCount = VisualTreeHelper.GetChildrenCount(parent);
				for (int i = 0; i < childCount; i++)
				{
					var child = VisualTreeHelper.GetChild(parent, i);
					buttons.AddRange(FindAllButtons(child));
				}
			}
			return buttons;
		}

		private void FillButtons()
		{
			List<string> styles = new() { "purpleButton", "whiteButton", "blueButton", "greenButton", "redButton", "yellowButton" };
			List<int> nums = new();
			for (int i = 1; i <= 48; i++)
				nums.Add(i);

			Shuffle(nums);

			List<Border> buttons = FindAllButtons(grid);

			int counter = 1;
			foreach (var btn in buttons)
			{
				if (btn.Name == "eyeIcon")
					continue;

				var textBlock = btn.Child as TextBlock;
				textBlock.Text = nums[counter - 1].ToString();
				btn.Style = (Style)Resources[styles[random.Next(0, 6)]];
				counter++;
			}
		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var btn = sender as Border;
			var textBlock = btn.Child as TextBlock;
	
			if (index == buttonsCount)
			{
				btn.Style = (Style)Resources["pressedButton"];
				MessageBox.Show(
					$"You win!\n" +
					$"Time: {gameTime}s.");
				FillButtons();
				StartTimer();
				index = 1;
				return;
			}
			else if (Int32.Parse(textBlock.Text.ToString()) == index)
			{
				btn.Style = (Style)Resources["pressedButton"];
				index++;
			}
		}
	}
}
