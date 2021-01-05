using System;
using System.IO;
using System.Text;
using HarmonyLib;

namespace Astro.Implant
{
    [HarmonyPatch(typeof(Main.AuthLib.Client))]
    [HarmonyPatch("Version", typeof(string))]
    public class Main_AuthLib_Client_Version
    {
        static bool Prefix(Main.AuthLib.Client __instance, ref string Output)
        {
            ConsoleManager.Log($"Main.AuthLib.Client.Version(string Output): Output = {Output}");

            return true;
        }

        static void Postfix(ref bool __result)
        {
            ConsoleManager.Log($"Main.AuthLib.Client.Version(string Output): __result = {__result}");
        }
    }
}
