using System;
using System.Collections.Generic;
using System.IO;

namespace NetworkTypes
{
	[Serializable]
	public class Group
	{
		public Group()
		{
		}

		public Group(int ID, int UID, string Name)
		{
			this.ID = ID;
			this.UID = UID;
			this.Name = Name;
			this.Image = this.TryReadProductImage();
		}

		private byte[] TryReadProductImage()
		{
			List<byte> list = new List<byte>();
			try
			{
				if (File.Exists(Environment.CurrentDirectory + "\\Images\\Groups\\" + this.Name + ".png"))
				{
					using (FileStream fileStream = File.Open(Environment.CurrentDirectory + "\\Images\\Groups\\" + this.Name + ".png", FileMode.Open, FileAccess.Read, FileShare.None))
					{
						byte[] array = new byte[(int)fileStream.Length];
						int num = (int)fileStream.Length;
						int num2 = 0;
						int num3 = 0;
						//Console.WriteLine("File Length: " + num.ToString());
						//Console.WriteLine("Read: " + num2.ToString());
						while ((num2 = fileStream.Read(array, num2, num - num2)) != 0)
						{
							list.AddRange(array);
							//Console.WriteLine("File Length: " + num.ToString());
							//Console.WriteLine("Read: " + num2.ToString());
							num3 += num2;
						}
						goto IL_127;
					}
				}
				Console.WriteLine(string.Concat(new string[]
				{
					"Server cant find Product Image -> ",
					Environment.CurrentDirectory,
					"\\Images\\",
					this.Name,
					".png"
				}));
				IL_127:;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			//Console.WriteLine("Product: " + this.Name + " Image Size: " + list.Count.ToString());
			return list.ToArray();
		}

		public int ID;

		public int UID;

		public string Name;

		public byte[] Image;
	}
}
