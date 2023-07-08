using ClassLibrary.Models;
using PropertyChanged;
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
    [AddINotifyPropertyChangedInterface]
    public partial class ChatMessage : UserControl
    {
        public ChatMessage()
        {
            InitializeComponent();
        }

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register("Username", typeof(string), typeof(ChatMessage));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(ChatMessage));

		public Brush Color
		{
			get { return (Brush)GetValue(ColorProperty); }
			set { SetValue(ColorProperty, value); }
		}

		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Brush), typeof(ChatMessage));

        public string TimeNow
        {
            get
            {
                return DateTime.Now.ToShortTimeString().ToString();
            }
        }

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
