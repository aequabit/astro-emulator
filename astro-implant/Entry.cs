using System;
using System.IO;
using System.Reflection;
using HarmonyLib;

namespace Astro.Implant
{
    public class Entry
    {
        private const string HARMONY_ID = "astro-implant";

        public static int Load(string pwzArgument)
        {
            ConsoleManager.Create();

            ConsoleManager.Log($"Successfully loaded into {Path.GetFileName(Assembly.GetEntryAssembly().Location)} (AppDomain.CurrentDomain.Id = {AppDomain.CurrentDomain.Id}, pwzArgument = {pwzArgument})");

            try
            {
                var harmony = new Harmony(HARMONY_ID);
                harmony.PatchAll();
            }
            catch (Exception e)
            {
                ConsoleManager.Log($"Exception: {e}");

                return 1;
            }

            return 0;
        }
    }
}
