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

	public class ViewModel
	{
		private ObservableCollection<Contact> contacts = new();
		public IEnumerable<Contact> Contacts => contacts;
		public Contact SelectedContact { get; set; }

		public ViewModel()
		{
			contacts.Add(new Contact { Name = "user1", Surname = "surnameUser1", Phone = "+38098318911", Country = "Ukraine" });
		}

		public void AddContact()
		{
			if (SelectedContact != null)
				this.contacts.Add(SelectedContact);
		}

		public void RemoveContact()
		{
			if (SelectedContact != null)
				this.contacts.Remove(SelectedContact);
		}
	}

	[PropertyChanged.AddINotifyPropertyChangedInterface]
	public class Contact
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

		public override string ToString()
		{
			return $"{Name} {Surname} : {Phone}";
		}
	}
}
