using System;

namespace NetworkTypes
{
	[Serializable]
	public class Account
	{
		public Account(int UserID, string Username, Account.Bans Ban)
		{
			this.UserID = UserID;
			this.Username = Username;
			this.Ban = Ban;
		}

		public int UserID;

		public string Username;

		public Account.Bans Ban;

		[Flags]
		public enum Bans
		{
			NotBanned = -1,
			Silent = 0,
			Perma = 1
		}
	}
}
