using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using Hal.Engine.Formatter;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Hal.Engine.Extensibility.Formatter;
using Hal.Engine.Extensibility.Hypermedia;

namespace Hal.Engine
{
    public class JsonHalMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private const string HalMediaType = "application/hal+json";
        private readonly IDictionary<string, IHypermediaFormatter> formatters;

        public JsonHalMediaTypeFormatter()
        {
            SupportedMediaTypes.Clear();
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(HalMediaType));
            SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters = new Dictionary<string, IHypermediaFormatter>
            {
                { typeof(IHypermedia).Name, new HypermediaFormatter() },
                { typeof(ILinksHypermedia).Name, new LinkHypermediaFormatter() },
                { typeof(IListHypermedia<>).Name, new ListHypermediaFormatter() }
            };
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, Encoding effectiveEncoding)
        {
            IEnumerable<string> interfacesName = GetInterfacesName(type);
            var resource = value as IHypermedia;
            foreach (string interfaceName in interfacesName)
            {
                if (formatters.ContainsKey(interfaceName))
                {
                    IHypermediaFormatter formatter = formatters[interfaceName];
                    formatter.Formating(resource);
                }
            }

            base.WriteToStream(type, resource, writeStream, effectiveEncoding);
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(IHypermedia).IsAssignableFrom(type);
        }

        private static IEnumerable<string> GetInterfacesName(Type type)
        {
            IList<string> interfacesName = type.GetInterfaces().Where(t => t != typeof(IHypermedia)).Select(t=>t.Name).ToList();
            interfacesName.Insert(0, typeof(IHypermedia).Name);
            return interfacesName;
        }
    }
}