using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Main
{
	public class Natives
	{
		[DllImport("uxtheme", ExactSpelling = true)]
		public static extern int DrawThemeParentBackground(IntPtr hWnd, IntPtr hdc, ref Rectangle pRect);

		[DllImport("user32.dll")]
		private static extern IntPtr GetShellWindow();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, int lpram);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		private delegate bool EnumWindowsProc(IntPtr hWnd, int lpram);
	}
}
