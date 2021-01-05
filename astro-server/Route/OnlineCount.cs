using System;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("OnlineCount")]
    class OnlineCount : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (OnlineCount)");

            return new Response("", "1488");
        }
    }
}
