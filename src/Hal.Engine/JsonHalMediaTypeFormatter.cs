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
            MethodInfo methodInfo = type.GetMethod("Hal.Engine.Extensibility.IRepresentation.CreateHypermedia", BindingFlags.Instance | BindingFlags.NonPublic);
            ILinksResource resource = value as ILinksResource;
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
            return typeof(IRepresentation).IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(IRepresentation).IsAssignableFrom(type);
        }
    }
}