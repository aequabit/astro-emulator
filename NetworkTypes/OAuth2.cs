using System;

namespace NetworkTypes
{
	[Serializable]
	public class OAuth2
	{
		public OAuth2()
		{
		}

		public OAuth2(int UserID, string PermaToken, string AccessToken, string RefreshToken, DateTime Expiry)
		{
			this.UserID = UserID;
			this.PermaToken = PermaToken;
			this.AccessToken = AccessToken;
			this.RefreshToken = RefreshToken;
			this.Expiry = Expiry;
		}

		public int UserID;

		public string PermaToken;

		public string AccessToken;

		public string RefreshToken;

		public DateTime Expiry;
	}
}
