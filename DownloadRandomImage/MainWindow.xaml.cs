using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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

namespace DownloadRandomImage
{
	public partial class MainWindow : Window
	{
		private WebClient webClient;
		private string destinationFile;
        public MainWindow()
		{
			InitializeComponent();
			webClient = new WebClient();
			webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
			webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
			destinationTxtBox.Text = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\images";
		}	

		private void AddHistoryItem(string fileName)
		{
			historyListBox.Items.Add($"{DateTime.Now.ToShortTimeString()}: {fileName}");
		}

		private void ChooseDirectoryBtnClick(object sender, RoutedEventArgs e)
		{
			using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
			{
				if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					destinationTxtBox.Text = dialog.SelectedPath;
				}
			}
		}

		private void DownloadImageBtnClick(object sender, RoutedEventArgs e)
		{
			if (webClient.IsBusy)
				return;

			if (string.IsNullOrWhiteSpace(heightTxtBox.Text) ||
				string.IsNullOrWhiteSpace(widthTxtBox.Text) ||
				string.IsNullOrWhiteSpace(destinationTxtBox.Text))
			{
				MessageBox.Show("Enter valid data!");
				return;
			}
			var width = widthTxtBox.Text;
			var height = heightTxtBox.Text;
			string? category = categoryTxtBox.Text;
			string url = $"https://source.unsplash.com/random/{width}x{height}/?{category}&1";
			string name = Guid.NewGuid().ToString();
			string dest = $"{destinationTxtBox.Text}\\{name}.jpeg";

			destinationFile = dest;

			webClient.DownloadFileAsync(new Uri(url), dest);
		}

		private void WebClient_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
		{
			MessageBox.Show("Download completed!");
			progressBar.Value = 0;
			AddHistoryItem(destinationFile);
			new Process { StartInfo = new ProcessStartInfo(destinationFile) { UseShellExecute = true } }.Start();
		}

		private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			progressBar.Value = e.ProgressPercentage;
		}
	}
}
