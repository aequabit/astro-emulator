using System;

namespace NetworkTypes
{
	[Serializable]
	public class Notification
	{
		public string notificationType { get; set; }

		public DateTime readDate { get; set; }

		public notificationData notificationData { get; set; }
	}
}
