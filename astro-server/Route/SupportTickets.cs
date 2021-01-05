using System;
using System.Collections.Generic;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("SupportTickets")]
    class SupportTickets : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (SupportTickets)");

            return new Response("Tickets", Config.Default.SupportTickets);
        }
    }
}
