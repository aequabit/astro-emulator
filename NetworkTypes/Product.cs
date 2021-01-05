using System;
using System.Collections.Generic;
using System.IO;

namespace NetworkTypes
{
	[Serializable]
	public class Product
	{
		public Product()
		{
		}

		public Product(int ID, int UID, int IPSGroup, int ProductGroup, string Name, string File, string ProcessName, int Status, int Version, int Free, bool Internal, bool BattlEye, int OnlineCount)
		{
			this.ID = ID;
			this.UID = UID;
			this.IPSGroup = IPSGroup;
			this.ProductGroup = ProductGroup;
			this.Name = Name;
			this.File = File;
			this.ProcessName = ProcessName;
			this.Status = Status;
			this.Version = Version;
			this.Free = Free;
			this.Internal = Internal;
			this.BattlEye = BattlEye;
			this.OnlineCount = OnlineCount;
			this.Image = this.TryReadProductImage();
		}

		private byte[] TryReadProductImage()
		{
			List<byte> list = new List<byte>();
			try
			{
				if (System.IO.File.Exists(Environment.CurrentDirectory + "\\Images\\Products\\" + this.Name + ".png"))
				{
					using (FileStream fileStream = System.IO.File.Open(Environment.CurrentDirectory + "\\Images\\Products\\" + this.Name + ".png", FileMode.Open, FileAccess.Read, FileShare.None))
					{
						byte[] array = new byte[(int)fileStream.Length];
						int num = (int)fileStream.Length;
						int num2 = 0;
						int num3 = 0;
						Console.WriteLine("File Length: " + num.ToString());
						Console.WriteLine("Read: " + num2.ToString());
						while ((num2 = fileStream.Read(array, num2, num - num2)) != 0)
						{
							list.AddRange(array);
							Console.WriteLine("File Length: " + num.ToString());
							Console.WriteLine("Read: " + num2.ToString());
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
			Console.WriteLine("Product: " + this.Name + " Image Size: " + list.Count.ToString());
			return list.ToArray();
		}

		public int ID;

		public int UID;

		public int IPSGroup;

		public int ProductGroup;

		public string Name;

		public string File;

		public string ProcessName;

		public int Status;

		public int Version;

		public int Free;

		public bool Internal;

		public bool BattlEye;

		public int OnlineCount;

		public byte[] Image;
	}
}
