using System;

namespace NetworkTypes
{
	[Serializable]
	public class Error
	{
		public string error { get; set; }

		public string errorCode
		{
			set
			{
				this.error = value;
			}
		}

		public string error_description { get; set; }

		public string errorMessage
		{
			set
			{
				this.error_description = value;
			}
		}
	}
}
