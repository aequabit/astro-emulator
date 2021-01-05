using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Main.Functions
{
	public class FingerPrint
	{
		public static string Value()
		{
			bool flag = FingerPrint.HWID == "";
			if (flag)
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + "--------------------------------------------------");
				FingerPrint.BIOS = FingerPrint.GetHash(FingerPrint.biosId(), false);
				Console.WriteLine(FingerPrint.BIOS + " found in " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms");
				FingerPrint.BASE = FingerPrint.GetHash(FingerPrint.baseId(), false);
				Console.WriteLine(FingerPrint.BASE + " found in " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms");
				FingerPrint.CPU = FingerPrint.GetHash(FingerPrint.cpuId(), false);
				Console.WriteLine(FingerPrint.CPU + " found in " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms");
				FingerPrint.VIDEO = FingerPrint.GetHash(FingerPrint.videoId(), false);
				Console.WriteLine(FingerPrint.VIDEO + " found in " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms");
				FingerPrint.SYSTEM = FingerPrint.GetHash("", false);
				Console.WriteLine(FingerPrint.SYSTEM + " found in " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms");
				FingerPrint.DISKS = FingerPrint.GetHash(FingerPrint.diskId(), false);
				Console.WriteLine(FingerPrint.DISKS + " found in " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms");
				File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + "--------------------------------------------------");
				FingerPrint.HWID = FingerPrint.GetHash(string.Concat(new string[]
				{
					"BIOS >> ",
					FingerPrint.BIOS,
					"\nBASE >> ",
					FingerPrint.BASE,
					"\nCPU >> ",
					FingerPrint.CPU,
					"\nVIDEO >> ",
					FingerPrint.VIDEO,
					"\nOS >> ",
					FingerPrint.SYSTEM,
					"\nDISKS >> ",
					FingerPrint.DISKS
				}), true);
				Console.WriteLine("Hashed all Hardware Serials in " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms");
				Console.WriteLine("Hashed all Hardware Serials: " + FingerPrint.HWID);
			}
			else
			{
				Console.WriteLine("Fingerprint Exists");
			}
			return FingerPrint.HWID;
		}

		public static string GetHash(string s, bool seperators = false)
		{
			MD5 md = new MD5CryptoServiceProvider();
			ASCIIEncoding asciiencoding = new ASCIIEncoding();
			byte[] bytes = asciiencoding.GetBytes(s);
			string result;
			if (seperators)
			{
				result = FingerPrint.GetHexString(md.ComputeHash(bytes));
			}
			else
			{
				result = FingerPrint.GetHexString(md.ComputeHash(bytes)).Replace("-", "");
			}
			return result;
		}

		private static string GetHexString(byte[] bt)
		{
			string text = string.Empty;
			for (int i = 0; i < bt.Length; i++)
			{
				byte b = bt[i];
				int num = (int)b;
				int num2 = num & 15;
				int num3 = num >> 4 & 15;
				bool flag = num3 > 9;
				if (flag)
				{
					text += ((char)(num3 - 10 + 65)).ToString();
				}
				else
				{
					text += num3.ToString();
				}
				bool flag2 = num2 > 9;
				if (flag2)
				{
					text += ((char)(num2 - 10 + 65)).ToString();
				}
				else
				{
					text += num2.ToString();
				}
				bool flag3 = i + 1 != bt.Length && (i + 1) % 2 == 0;
				if (flag3)
				{
					text += "-";
				}
			}
			return text;
		}

		private static string identifier(string wmiClass, string wmiProperty)
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select " + wmiProperty + " From " + wmiClass);
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			string text = "";
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				try
				{
					text = text + managementObject[wmiProperty].ToString() + ",";
				}
				catch
				{
				}
			}
			return text.TrimEnd(new char[]
			{
				','
			});
		}

		private static string identifier(string wmiClass, string[] wmiProperties, string where = "")
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * FROM " + wmiClass + ((where != "") ? (" WHERE " + where) : ""));
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			string text = "";
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				foreach (string propertyName in wmiProperties)
				{
					try
					{
						bool flag = managementObject[propertyName] != null;
						if (flag)
						{
							text = text + managementObject[propertyName].ToString() + ",";
						}
					}
					catch
					{
					}
				}
			}
			return text.TrimEnd(new char[]
			{
				','
			});
		}

		private static string biosId()
		{
			string text = FingerPrint.identifier("Win32_BIOS", new string[]
			{
				"Manufacturer",
				"SerialNumber"
			}, "");
			File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + text);
			return text;
		}

		private static string baseId()
		{
			string text = FingerPrint.identifier("Win32_BaseBoard", new string[]
			{
				"Name",
				"Model",
				"Product",
				"Manufacturer",
				"SerialNumber"
			}, "");
			File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + text);
			return text;
		}

		private static string cpuId()
		{
			string text = FingerPrint.identifier("Win32_Processor", new string[]
			{
				"Name",
				"Manufacturer",
				"ProcessorId"
			}, "");
			File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + text);
			return text;
		}

		private static string videoId()
		{
			string text = FingerPrint.identifier("Win32_VideoController", new string[]
			{
				"Name",
				"VideoProcessor"
			}, "");
			File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + text);
			return text;
		}

		private static string OSid()
		{
			string text = FingerPrint.identifier("Win32_OperatingSystem", new string[]
			{
				"Name",
				"CSName",
				"RegisteredUser"
			}, "");
			File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + text);
			return text;
		}

		private static string diskId()
		{
			string text = FingerPrint.identifier("Win32_DiskDrive", new string[]
			{
				"Name",
				"Model",
				"SerialNumber"
			}, "Index='0' AND MediaType='Fixed hard disk media'");
			File.AppendAllText(Environment.CurrentDirectory + "\\HWID.txt", Environment.NewLine + text);
			return text;
		}

		private static string BIOS = "";

		private static string BASE = "";

		private static string CPU = "";

		private static string VIDEO = "";

		private static string DISKS = "";

		private static string SYSTEM = "";

		public static string HWID = "";
	}
}
