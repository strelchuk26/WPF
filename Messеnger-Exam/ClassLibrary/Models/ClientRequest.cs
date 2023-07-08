using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
	[Serializable]
	public enum RequestCommand
	{
		Join, Leave, Message, GetMembers
	}
	[Serializable]
	public class ClientCommand
	{
		public string Username { get; set; }
		public RequestCommand Command { get; set; }
		public string Message { get; set; }
		public Color MessageColor { get; set; }
        public List<string> MembersNames { get; set; }

        public ClientCommand() { }
		public ClientCommand(RequestCommand cmd)
		{
			Command = cmd;
		}
		public ClientCommand(RequestCommand cmd, string username)
		{
			Command = cmd;
			Username = username;
		}
	}
}
