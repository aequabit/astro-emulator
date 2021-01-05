using System;

namespace NetworkTypes
{
	[Serializable]
	public class OAuth2_Auth
	{
		public OAuth2_Auth()
		{
		}

		public OAuth2_Auth(string PermaToken, string HWID)
		{
			this.PermaToken = PermaToken;
			this.HWID = HWID;
		}

		public string PermaToken;

		public string HWID;
	}
}
