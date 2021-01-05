using System;

namespace NetworkTypes
{
	[Serializable]
	public class SupportReply
	{
		public int id { get; set; }

		public string item_id { get; set; }

		public Author author { get; set; }

		public DateTime date { get; set; }

		public string content
		{
			get
			{
				return this.content_clean;
			}
			set
			{
				this.content_clean = value.TrimStart(new char[]
				{
					'\n'
				}).TrimStart(new char[]
				{
					'\t'
				});
			}
		}

		public string content_clean { get; set; }

		public bool hidden { get; set; }

		public string url { get; set; }
	}
}
