using NetworkTypes;

namespace Astro.Server.Net
{
    interface IAstroRoute
    {
        Response Handle(Request request);
    }
}
