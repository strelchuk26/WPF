using System;
using System.Collections;
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

namespace ShulteTable
{
	public partial class MainWindow : Window
	{
		Random random = new Random();
		public MainWindow()
		{
			InitializeComponent();
			FillButtons();
		}

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
		public List<Button> FindAllButtons(DependencyObject parent)
		{
			List<Button> buttons = new List<Button>();

			if (parent is Button button)
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

			List<Button> buttons = FindAllButtons(grid);

			int counter = 1;
			foreach (var btn in buttons)
			{
				if (btn.Name == "eyeIcon")
				{
					btn.Content = "X";
					continue;
				}

				btn.Content = nums[counter - 1].ToString();
				btn.Style = (Style)Resources[styles[random.Next(0, 6)]];
				counter++;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var btn = sender as Button;


		}
	}
}
