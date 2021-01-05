using System;
using System.IO;
using System.Text;
using HarmonyLib;

namespace Astro.Implant
{
    [HarmonyPatch(typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter))]
    [HarmonyPatch("Deserialize", typeof(Stream))]
    public class System_Runtime_Serialization_Formatters_Binary_BinaryFormatter_Deserialize
    {
        static bool Prefix(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter __instance, ref Stream serializationStream)
        {
            var buffer = new byte[serializationStream.Length];
            serializationStream.Read(buffer, 0, buffer.Length);
            var str = Encoding.UTF8.GetString(buffer);

            ConsoleManager.Log($"System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream): data = {str}");

            return true;
        }
    }
}
