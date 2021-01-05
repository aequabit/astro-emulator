using System;
using System.IO;
using Astro.Server.Net;
using NetworkTypes;

namespace Astro.Server.Route
{
    [AstroRoute("Download")]
    class Download : IAstroRoute
    {
        public Response Handle(Request request)
        {
            var product = (Product)request.Object;

            Console.WriteLine($"Request (Download): Product.Name = {product.Name}");

            var productPath = AppDomain.CurrentDomain.BaseDirectory + "Products\\" + product.Name + ".zip";
            if (!File.Exists(productPath))
                throw new Exception("retard");

            var data = File.ReadAllBytes(productPath);
            var dataStream = new MemoryStream(data);

            return new Response("Download", dataStream);
        }
    }
}
