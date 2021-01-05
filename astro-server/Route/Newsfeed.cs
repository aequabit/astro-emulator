using System;
using System.Collections.Generic;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Newsfeed")]
    class Newsfeed : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Newsfeed)");

            return new Response("", Config.Default.News);
        }
    }
}
