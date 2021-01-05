using System;

namespace NetworkTypes
{
	[Serializable]
	public class HWID
	{
		public HWID()
		{
		}

		public HWID(int UserID, string HWIDStatus, int HWIDResets)
		{
			this.UserID = UserID;
			this.HWIDStatus = HWIDStatus;
			this.HWIDResets = HWIDResets;
		}

		public HWID(string Username, string Password, string HWIDStatus, int HWIDResets)
		{
			this.Username = Username;
			this.Password = Password;
			this.HWIDStatus = HWIDStatus;
			this.HWIDResets = HWIDResets;
		}

		public int UserID;

		public string Username;

		public string Password;

		public string HWIDStatus;

		public int HWIDResets;
	}
}
