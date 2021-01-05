using System;

namespace NetworkTypes
{
	[Serializable]
	public class Response
	{
		public Response(string Message, object Object = null, bool Error = false)
		{
			this.Message = Message;
			this.Object = Object;
			this.Error = Error;
		}

		public string Message;

		public object Object;

		public bool Error;
	}
}
