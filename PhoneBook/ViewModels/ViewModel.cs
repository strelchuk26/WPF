using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PhoneBook
{
	[AddINotifyPropertyChangedInterface]
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
}
