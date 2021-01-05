using System;
using System.Collections.Generic;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Groups")]
    class Groups : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Groups)");

            return new Response("", Config.Default.Groups);
        }
    }
}
