using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Main
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\alert\\", false);
			}
			catch
			{
				MessageBox.Show("Failed to Clean Up Traces (.reg)");
			}
			List<Process> list = new List<Process>(from process in Process.GetProcessesByName(Brand.ProcName)
			where process.Id != Process.GetCurrentProcess().Id
			select process);
			bool flag = list.Count > 0;
			if (flag)
			{
				foreach (Process process2 in list)
				{
					process2.Kill();
				}
			}
			new Thread(delegate()
			{
				for (;;)
				{
					List<Process> list2 = new List<Process>();
					list2.AddRange(Process.GetProcessesByName("beservice"));
					bool flag2 = list2.Count > 0;
					if (flag2)
					{
						list2.ForEach(delegate(Process process)
						{
							process.Kill();
						});
					}
					Thread.Sleep(500);
				}
			}).Start();
			
			EmbeddedResource.LoadAssembly("Main.Resources.Bunifu_UI_v1.52.dll", "Bunifu_UI_v1.52.dll");
			EmbeddedResource.LoadAssembly("Main.Resources.CustomTheme.dll", "CustomTheme.dll");
			EmbeddedResource.LoadAssembly("Main.Resources.NetworkTypes.dll", "NetworkTypes.dll");
			EmbeddedResource.LoadResource("Main.Resources.Logo (40x40).gif", "Logo (40x40).gif");
			EmbeddedResource.LoadResource("Main.Resources.DropDown.png", "DropDown.png");
			EmbeddedResource.LoadResource("Main.Resources.DropUp.png", "DropUp.png");
			EmbeddedResource.LoadResource("Main.Resources.Astro.Astro_Header.png", "Astro_Header.png");
			EmbeddedResource.LoadResource("Main.Resources.Maverick.Maverick_Header.png", "Maverick_Header.png");
			EmbeddedResource.LoadResource("Main.Resources.Astro.Astro_Icon.png", "Astro_Icon.png");
			EmbeddedResource.LoadResource("Main.Resources.Maverick.Maverick_Icon.png", "Maverick_Icon.png");
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			AppDomain.CurrentDomain.AssemblyResolve += Program.CurrentDomain_AssemblyResolve;
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs arg)
			{
				Program.HandleUnhandledException(arg.ExceptionObject as Exception);
			};
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}

		public static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			return EmbeddedResource.Get(args.Name);
		}

		public static void HandleUnhandledException(Exception ex)
		{
			MessageBox.Show("Send to Developer! -> Exception: " + ex.ToString());
		}
	}
}
