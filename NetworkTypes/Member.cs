using System;
using System.Drawing;

namespace NetworkTypes
{
	[Serializable]
	public class Member
	{
		public Member(int UserID, string Username, Image Avatar)
		{
			this.UserID = UserID;
			this.Username = Username;
			if (Avatar != null)
			{
				this.Avatar = (Bitmap)Avatar.Clone();
				return;
			}
			Avatar = null;
		}

		public int UserID;

		public string Username;

		public Image Avatar;
	}
}
