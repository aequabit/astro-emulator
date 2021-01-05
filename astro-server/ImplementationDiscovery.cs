using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Astro.Server
{
    static class ImplementationDiscovery
    {
        public static Dictionary<TAttribute, Type> First<TAttribute, TInterface>(AppDomain appDomain)
        {
            var assemblies = appDomain.GetAssemblies();

            var final = new Dictionary<TAttribute, Type>();

            foreach (var assembly in assemblies)
            {
                var aseemblyTypes = assembly.GetTypes();

                foreach (var type in aseemblyTypes)
                {
                    if (type.IsDefined(typeof(TAttribute), true))
                    {
                        if (!typeof(TInterface).IsAssignableFrom(type))
                            throw new Exception($"Route type {type.Name} does not implement interface");
                       
                        var attribute = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault();
                        if (attribute == null)
                            throw new Exception($"Type {type.Name} does not use attribute");

                        final.Add((TAttribute)attribute, type);
                    }
                }
            }

            return final;
        }
    }
}
