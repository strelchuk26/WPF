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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.CustomControls
{
	public partial class ChatMember : UserControl
	{
		public ChatMember()
		{
			InitializeComponent();
		}

		public string Username
		{
			get { return (string)GetValue(UsernameProperty); }
			set { SetValue(UsernameProperty, value); }
		}

		public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register("Username", typeof(string), typeof(ChatMember));

		public string FirstSymbOfUsername
		{
			get
			{
				var chars = Username.ToCharArray();
				return Char.ToUpper(chars[0]).ToString();
			}
		}
	}
}
