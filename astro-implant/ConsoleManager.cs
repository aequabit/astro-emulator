using System;
using System.Runtime.InteropServices;

namespace Astro.Implant
{
    public class ConsoleManager
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MAXIMIZE = 0xF030;

        private static object _lock = new object();

        public static void Create()
        {
            AllocConsole();
        }

        public static void Log(string message)
        {
            lock (_lock)
            {
                Console.WriteLine(message);
            }
        }
    }
}
