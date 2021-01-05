using System;

namespace NetworkTypes
{
	[Serializable]
	public class Login
	{
		public Login()
		{
		}

		public Login(string Username, string Password, string HWID = "")
		{
			this.Username = Username;
			this.Password = Password;
			this.HWID = HWID;
		}

		public string Username;

		public string Password;

		public string HWID;
	}
}
