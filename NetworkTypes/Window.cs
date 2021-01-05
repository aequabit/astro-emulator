using System;

namespace NetworkTypes
{
	[Serializable]
	public class Window
	{
		public Window(string ClassName, string WindowTitle)
		{
			this.ClassName = ClassName;
			this.WindowTitle = WindowTitle;
		}

		public string ClassName;

		public string WindowTitle;
	}
}
