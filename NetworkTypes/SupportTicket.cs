using System;

namespace NetworkTypes
{
	[Serializable]
	public class SupportTicket
	{
		public int id { get; set; }

		public string title { get; set; }

		public SupportReply firstMessage { get; set; }
	}
}
