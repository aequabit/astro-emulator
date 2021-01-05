using System;

namespace NetworkTypes
{
	[Serializable]
	public class notificationData
	{
		public string title { get; set; }

		public string url { get; set; }

		public string content { get; set; }

		public Author author { get; set; }

		public bool unread { get; set; }
	}
}
