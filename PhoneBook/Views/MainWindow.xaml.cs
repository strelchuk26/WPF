using System;
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

namespace PhoneBook
{
	public partial class MainWindow : Window
	{
		private ViewModel viewmodel = new();
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = viewmodel;
		}

		private void addBtnClick(object sender, RoutedEventArgs e)
		{
			viewmodel.AddContact();
		}

		private void removeBtnClick(object sender, RoutedEventArgs e)
		{
			viewmodel.RemoveContact();
		}
	}
}
