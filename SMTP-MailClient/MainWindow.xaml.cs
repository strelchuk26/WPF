using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit.Cryptography;
using Org.BouncyCastle.Asn1.X509;
using SMTP_MailClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SMTP_MailClient
{
	public partial class MainWindow : Window
	{
		private string userMail = "yourgmail@gmail.com";
		private string userPassword = "yourpassword";
		private Message SelectedMessage;

        public MainWindow()
		{
			InitializeComponent();
		}

		public MainWindow(string mail, string password)
		{
			InitializeComponent();
			userMail = mail;
			userPassword = password;
		}

		private async void ShowInbox()
		{
			using (var client = new ImapClient())
			{
				await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
				await client.AuthenticateAsync(userMail, userPassword);
				await client.Inbox.OpenAsync(FolderAccess.ReadOnly);
				int counter = 0;
				foreach (UniqueId uid in await client.Inbox.SearchAsync(SearchQuery.All))
				{
					if (counter == 10)
						break;

					var msg = await client.Inbox.GetMessageAsync(uid);
					list.Items.Add(new Message
					{
						Id = uid.Id,
						Subject = msg.Subject,
						Date = msg.Date.ToString(),
						From = msg.From.ToString(),
						To = msg.To.ToString(),
						Text = msg.TextBody,
						AttachmentsCount = msg.Attachments.Count()
					});
					counter++;
				}
			}
		}

		private void ShowAllMessages(object sender, RoutedEventArgs e)
		{
			ShowInbox();
		}

		private void DeleteMessageBtnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void SelectedMessageChanged(object sender, SelectionChangedEventArgs e)
		{
			if (list.SelectedItem == null)
				return;

			SelectedMessage = list.SelectedItem as Message;
			msgDateTxtBlock.Text = SelectedMessage.Date.ToString();
			msgFromTxtBlock.Text = SelectedMessage.From.ToString();
			msgSubjectTxtBlock.Text = SelectedMessage.Subject.ToString();
			msgTextTxtBlock.Text = SelectedMessage.Text;
        }
    }
}
