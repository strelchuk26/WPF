using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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

namespace SMTP_Mail
{
	public partial class MainWindow : Window
	{
		private string myMailAddress;
		private string accountPassword;
		private MailPriority mailPriority = MailPriority.Normal;

		public MainWindow()
		{
			InitializeComponent();
		}

		public MainWindow(string email, string password)
		{
			InitializeComponent();
			myMailAddress = email;
			accountPassword = password;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(toTxtBox.Text)
			 || string.IsNullOrWhiteSpace(subjectTxtBox.Text)
			 || string.IsNullOrWhiteSpace(bodyTxtBox.Text)
			 || priorityCmbBox.SelectedItem == null)
			{
				MessageBox.Show("Enter correct data!");
				return;
			}

			ComboBoxItem typeItem = (ComboBoxItem)priorityCmbBox.SelectedItem;
			string value = typeItem.Content.ToString();
			switch (value)
			{
				case "Low":
					mailPriority = MailPriority.Low;
					break;
				case "Normal":
					mailPriority = MailPriority.Normal;
					break;
				case "High":
					mailPriority = MailPriority.High;
					break;
				default:
					break;
			}

			// create new mail
			MailMessage mail = new MailMessage(myMailAddress, toTxtBox.Text)
			{
				Subject = subjectTxtBox.Text,
				Body = $"<h1>My Mail Message from C#</h1><p>{bodyTxtBox.Text}</p>",
				IsBodyHtml = true,
				Priority = mailPriority
			};


			bool flag = true;
			while (flag)
			{
				// add attachments
				var result = MessageBox.Show("Do you want to attach a file?", "Attach File", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					OpenFileDialog dialog = new OpenFileDialog();
					if (dialog.ShowDialog() == true)
						mail.Attachments.Add(new Attachment(dialog.FileName));
				}
				else
				{
					flag = false;
				}
			}

			// send mail message
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
			{
				Credentials = new NetworkCredential(myMailAddress, accountPassword),
				EnableSsl = true
			};

			client.Send(mail);
			MessageBox.Show("Message sent!");
		}
	}
}
