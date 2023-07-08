using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
	[Serializable]
	public class Member
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public TcpClient ClientData { get; set; }
	}
}
