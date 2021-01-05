using System;

namespace NetworkTypes
{
	[Serializable]
	public class News
	{
		public News()
		{
		}

		public News(int ID, int ProductId, string Content, DateTime PostDate)
		{
			this.ID = ID;
			this.ProductId = ProductId;
			this.Content = Content;
			this.PostDate = PostDate;
		}

		public int ID;

		public int ProductId;

		public string Content;

		public DateTime PostDate;
	}
}
