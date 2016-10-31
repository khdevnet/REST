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
            MethodInfo methodInfo = type.BaseType.GetMethod("CreateHypermedia", BindingFlags.Instance | BindingFlags.NonPublic);
            Representation resource = value as Representation;
            if (methodInfo != null)
            {
                methodInfo.Invoke(resource, null);
                UrlHelper url = new UrlHelper(HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage);
                resource.Links = resource.Links.Select(x => new Link(x.Rel, url.Content(x.Href))).ToList();
            }
            base.WriteToStream(type, resource, writeStream, effectiveEncoding);
        }

        public override bool CanReadType(Type type)
        {
            return typeof(Representation<>).IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(Representation).IsAssignableFrom(type);
        }
    }
}