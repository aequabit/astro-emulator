using System;

namespace Astro.Server.Net
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class AstroRouteAttribute : Attribute
    {
        public string Route { get; set; }

        public AstroRouteAttribute(string route)
        {
            Route = route;
        }
    }
}
