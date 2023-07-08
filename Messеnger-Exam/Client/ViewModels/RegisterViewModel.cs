using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClassLibrary.Models;
using PropertyChanged;

namespace Client.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	internal class RegisterViewModel
	{
		public Member currentMember;
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public ICommand RegisterCommand { get; }
		public ICommand CloseCommand { get; }

		public RegisterViewModel()
		{
			RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
			CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
		}

		private void ExecuteRegisterCommand(object obj)
		{
			currentMember = new Member()
			{
				Username = this.Username,
				Password = this.Password,
				Email = this.Email
			};

			MainWindow mainWindow = new MainWindow(currentMember);
			RegisterWindow thisWindow = Application.Current.Windows.OfType<RegisterWindow>().SingleOrDefault(x => x.IsActive);
			mainWindow.Show();
			thisWindow.Close();
		}

		private bool CanExecuteRegisterCommand(object arg)
		{
			Regex emailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
			bool validData;
			if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
				string.IsNullOrWhiteSpace(Password) || Password.Length < 8 ||
				string.IsNullOrWhiteSpace(Email) || emailRegex.IsMatch(Email) == false)
				validData = false;
			else
				validData = true;
			return validData;
		}

		private void ExecuteCloseCommand(object obj)
		{
			Application.Current.Shutdown();
		}
	}
}
