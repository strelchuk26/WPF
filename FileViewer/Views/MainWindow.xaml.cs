using Microsoft.Win32;
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

namespace FileViewer
{
	public partial class MainWindow : Window
	{
		public ViewModel viewModel = new();
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = viewModel;
		}

		private void OpenDirectoryBtnClick(object sender, RoutedEventArgs e)
		{
			viewModel.OpenDirectory();
		}

		private void PrevFileBtnClick(object sender, RoutedEventArgs e)
		{
			viewModel.PrevFile();
		}

		private void NextFileBtnClick(object sender, RoutedEventArgs e)
		{
			viewModel.NextFile();
		}

		private void OpenFileBtnClick(object sender, RoutedEventArgs e)
		{
			viewModel.OpenFile();
		}
	}
}
