using System;
using System.Collections.Generic;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Products")]
    class Products : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Products)");

            return new Response("Products", Config.Default.Products);
        }
    }
}
