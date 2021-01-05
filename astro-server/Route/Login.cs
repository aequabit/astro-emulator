using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Login")]
    class Login : IAstroRoute
    {
        public Response Handle(Request request)
        {
            var login = (NetworkTypes.Login)request.Object;

            Console.WriteLine($"Request (Login): Username={login.Username} Password={login.Password} HWID={login.HWID}");

            // TODO: Fix 
            // Check if the user exists
            //var member = Config.Default.Members.Find(x => x.Username.ToLower() == login.Username.ToLower());
            //if (member == default(Member))
            //    return new Response($"User {login.Username} does not exist", null, true);

            // Load avatar
            //var avatarPath = Environment.CurrentDirectory + "\\Images\\Users\\" + member.Username + ".png";
            //if (File.Exists(avatarPath))
            //    member.Avatar = Image.FromFile(avatarPath);

            var member = new Member(1, "AstroCheats", Image.FromFile(Environment.CurrentDirectory + "\\Images\\Users\\AstroCheats.png"));

            return new Response("", new Token(member, "token123"));
        }
    }
}
