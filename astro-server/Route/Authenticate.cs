using System;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Authenticate")]
    class Authenticate : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Authenticate): ProductID={request.Object}");

            return new Response("", "Authenticated");
        }
    }
}
