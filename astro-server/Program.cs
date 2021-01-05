using Astro.Server.Net;
using NetworkTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Astro.Server
{
    class Program
    {
        static void KillProcesses(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                foreach (var process in processes)
                {
                    try
                    {
                        process.Kill();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to kill process: {process.ProcessName}.exe: {ex.Message}");
                    }
                }
            }
        }

        static string RunProcess(string processName, string arguments)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = processName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                }
            };

            process.Start();

            // Read output
            string output = String.Empty;
            while (!process.StandardOutput.EndOfStream)
                output += process.StandardOutput.ReadLine();

            return output;
        }

        static void Main(string[] args)
        {
            // Create config if it doesn't exist
            if (!File.Exists(Config.Path))
            {
                var config = new Config();
                config.Populate();

                File.WriteAllText(Config.Path, XmlManager.Serialize(config));
            }

            // Load dependencies from embedded resources
            EmbeddedResource.LoadAssembly("Astro.Server.Resources.NetworkTypes.dll", "NetworkTypes.dll");

            // Register AppDomain events
            AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs arg)
            {
                return EmbeddedResource.Get(arg.Name);
            };

            AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs arg)
            {
                var ex = arg.ExceptionObject as Exception;
                Console.WriteLine($"Unhandled exception: {ex.Message + Environment.NewLine + ex.StackTrace}");
            };

            Console.Title = "astro-server";
            Console.WriteLine("astro-server - AstroCheats/MaverickCheats Server Emulator");
            Console.WriteLine("-");
            Console.WriteLine("");


            // Kill loader
            Console.WriteLine("Closing existing instances of AstroClient.exe and MaverickClient.exe...");
            KillProcesses("AstroClient");
            KillProcesses("MaverickClient");

            // Register netsh filter
            for (var i = 0; i < Config.Default.Hosts.Length; i++)
            {
                var result = RunProcess("netsh", $"int ip add addr {i + 1} {Config.Default.Hosts[i]}/32 st=ac sk=tr");
                Console.WriteLine($"Registering netsh filter, result: {result}");
            }

            // Register cancel operation to unregister filters
            Console.CancelKeyPress += delegate
            {
                for (var i = 0; i < Config.Default.Hosts.Length; i++)
                {
                    var result = RunProcess("netsh", $"int ip delete addr {i + 1} {Config.Default.Hosts[i]}");
                    Console.WriteLine($"Unregistering netsh filter, result: {result}");
                }

                Environment.Exit(0);
            };

            Console.WriteLine("Starting AstroCheats server on *:6161...");
            var serverAstro = new AstroListener(6161);
            serverAstro.Start();

            Console.WriteLine("Starting MaverickCheats server on *:6060...");
            var serverMaverick = new AstroListener(6060);
            serverMaverick.Start();

            while (true)
            {
            }
        }
    }
}
