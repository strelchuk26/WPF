using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ColorPicker
{
	public partial class MainWindow : Window
	{
		private ViewModel viewModel = new();
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = viewModel;
		}

		private void AddBtnClick(object sender, RoutedEventArgs e)
		{
			viewModel.AddColor();
		}

		private void RemoveBtnClick(object sender, RoutedEventArgs e)
		{
			viewModel.RemoveColor();
		}
	}

	[AddINotifyPropertyChangedInterface]
	public class ViewModel
	{
        private ObservableCollection<Color> colors = new();
		public IEnumerable<Color> Colors => colors;
        public CustomColor CustomColor { get; set; }
        public Color SelectedColor { get; set; }

        public ViewModel()
		{
			CustomColor = new();
			SelectedColor = new();

			colors.Add(Color.FromArgb(100, 10, 20, 30));
			colors.Add(Color.FromArgb(62, 56, 17, 8));
			colors.Add(Color.FromArgb(11, 0, 2, 77));
			colors.Add(Color.FromArgb(99, 123, 200, 5));
		}
		public void AddColor()
		{
			if (!colors.Contains(CustomColor.Color))
				this.colors.Add(CustomColor.Color);
			else
				MessageBox.Show("This color is already exist!");
		}

		public void RemoveColor()
		{
			if (SelectedColor != null)
				this.colors.Remove(SelectedColor);
		}
	}

	[AddINotifyPropertyChangedInterface]
	public class CustomColor
	{
        public byte Alpha { get; set; }
		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }

		public Color Color { get => Color.FromArgb(Alpha, Red, Green, Blue); }
    }
}
