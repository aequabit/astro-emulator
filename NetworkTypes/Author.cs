using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace NetworkTypes
{
	[Serializable]
	public class Author
	{
		public int id { get; set; }

		public string name { get; set; }

		public string title { get; set; }

		public string photoUrl { get; set; }

		public Image photo
		{
			get
			{
				if (this.Avatar == null)
				{
					byte[] buffer = new WebClient().DownloadData(this.photoUrl);
					return this.Avatar = Image.FromStream(new MemoryStream(buffer));
				}
				return this.Avatar;
			}
		}

		public Image Avatar;
	}
}
