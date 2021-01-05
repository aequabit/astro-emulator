using System;

namespace NetworkTypes
{
	[Serializable]
	public class Request
	{
		public Request()
		{
		}

		public Request(string Command, object Object = null)
		{
			this.Command = Command;
			this.Object = ((Object != null) ? Object : 0);
		}

		public Request(string Command, Token Token, object Object = null)
		{
			this.Command = Command;
			this.Token = Token;
			this.Object = ((Object != null) ? Object : 0);
		}

		public string Command;

		public Token Token;

		public object Object = 0;
	}
}
