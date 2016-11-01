using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using Hal.Engine.Extensibility;
using Hal.Engine.HypermediaFormatter;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Hal.Engine
{
    public class JsonHalMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private const string HalMediaType = "application/hal+json";
        private readonly IDictionary<string, IHypermediaFormatter> formatters;

        public JsonHalMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(HalMediaType));
            SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters = new Dictionary<string, IHypermediaFormatter>
            {
                { nameof(IHypermedia), new HypermediaFormatter.HypermediaFormatter() },
                { nameof(ILinksHypermedia), new LinkHypermediaFormatter() }
            };
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, Encoding effectiveEncoding)
        {
            IList<string> interfacesName = GetInterfacesName(type);
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
            return typeof(IHypermedia).IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(IHypermedia).IsAssignableFrom(type);
        }

        private static IList<string> GetInterfacesName(Type type)
        {
            IList<string> interfacesName = type.GetInterfaces().Where(x => x.Name != nameof(IHypermedia)).Select(i => i.Name).ToList();
            interfacesName.Insert(0, nameof(IHypermedia));
            return interfacesName;
        }
    }
}