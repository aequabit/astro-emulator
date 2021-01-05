using System;
using System.IO;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Updater")]
    class Updater : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Updater)");

            var data = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Update\\AstroClient.exe");
            var stream = new MemoryStream(data);

            return new Response("", stream);
        }
    }
}
