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
using System.Windows.Shapes;

namespace SMTP_MailClient
{
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void okBtnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(emailTxtBox.Text) || string.IsNullOrWhiteSpace(passwordTxtBox.Text))
			{
				MessageBox.Show("Enter correct data!");
				return;
			}

			MainWindow window = new MainWindow(emailTxtBox.Text, passwordTxtBox.Text);
			window.Show();
			this.Close();
		}

		private void cancelBtnClick(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
