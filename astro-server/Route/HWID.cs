using System;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("HWID")]
    class HWID : IAstroRoute
    {
        public Response Handle(Request request)
        {
            var login = (NetworkTypes.Login)request.Object;

            Console.WriteLine($"Request (HWID): Username={login.Username} Password={login.Password} HWID={login.HWID}");

            return new Response("", new NetworkTypes.HWID(login.Username, login.Password, "valid", 0));
        }
    }
}
