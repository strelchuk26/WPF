using PropertyChanged;

namespace PhoneBook
{
	[AddINotifyPropertyChangedInterface]
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
