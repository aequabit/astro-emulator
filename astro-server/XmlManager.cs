using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Astro.Server
{
    static class XmlManager
    {
        public static string Serialize<T>(T obj)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                // Create empty namespace
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                // Create writer
                var sw = new StringWriter();
                var xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings() {
                    OmitXmlDeclaration = true,
                    Indent = true
                });

                serializer.Serialize(xmlWriter, obj, ns);

                return sw.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to serialize object: {ex.Message}");
            }
        }

        public static T Deserialize<T>(string xml)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var reader = new StringReader(xml);
                return (T)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to deserialize object: {ex.Message}");
            }
        }
    }
}
