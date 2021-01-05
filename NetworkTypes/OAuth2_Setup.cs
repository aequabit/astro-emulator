using System;

namespace NetworkTypes
{
	[Serializable]
	public class OAuth2_Setup
	{
		public OAuth2_Setup()
		{
		}

		public OAuth2_Setup(string Code, string State, string HWID)
		{
			this.Code = Code;
			this.State = State;
			this.HWID = HWID;
		}

		public string Code;

		public string State;

		public string HWID;
	}
}
