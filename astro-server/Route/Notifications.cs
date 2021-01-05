using System;
using System.Collections.Generic;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Notifications")]
    class Notifications : IAstroRoute
    {
        public Response Handle(Request request)
        {
            Console.WriteLine($"Request (Notifications)");

            return new Response("Notifications", new List<Notification>(Config.Default.Notifications));
        }
    }
}
