using System;

namespace SMTP_MailClient
{
	public class Message
	{
        public uint Id { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public int AttachmentsCount { get; set; }

		public override string ToString()
		{
			return $"{From} {Subject} {Date}";
		}
	}
}
