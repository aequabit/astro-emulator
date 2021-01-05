using System;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Version")]
    class Version : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Version)");

            return new Response("", Config.Default.ClientVersion);
        }
    }
}
