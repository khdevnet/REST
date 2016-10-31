using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Routing;
using System.Web;
using Hal.Engine.Extensibility;
using System.Net.Http;
using Hal.Engine.Extensibility.Dto;
using Hal.Engine.HypermediaFormatter;

namespace Hal.Engine
{
    public class JsonHalMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private const string HalMediaType = "application/hal+json";

        public JsonHalMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(HalMediaType));
            SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, Encoding effectiveEncoding)
        {
            MethodInfo methodInfo = type.GetMethod("Hal.Engine.Extensibility.IHypermedia.Bind", BindingFlags.Instance | BindingFlags.NonPublic);
            var resource = value as IHypermedia;
            if (methodInfo != null)
            {
                methodInfo.Invoke(resource, null);
                var linkFormatter = new LinkHypermediaFormatter();
                linkFormatter.Formating(resource);
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
    }
}