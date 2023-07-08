using ClassLibrary.Models;
using Client.ViewModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace Client
{
	[AddINotifyPropertyChangedInterface]
	public partial class MainWindow : Window
	{
		MainViewModel viewModel;

		public MainWindow(Member member)
		{
			InitializeComponent();
			viewModel = new MainViewModel(member);
			this.DataContext = viewModel;
			Closing += viewModel.WindowClosed;
		}
	}
}
