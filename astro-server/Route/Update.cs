using System;
using System.IO;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Update")]
    class Update: IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Update)");

            var data = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Update\\AstroClient.exe");
            var stream = new MemoryStream(data);

            return new Response("", stream);
        }
    }
}
