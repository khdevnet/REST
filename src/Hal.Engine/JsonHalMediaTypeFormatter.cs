using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Hal.Engine.JsonConverters;

namespace Hal.Engine
{
    public class JsonHalMediaTypeFormatter : JsonMediaTypeFormatter
    {
     //   private readonly JsonConverter resourceListConverter = new ResourceListConverter();
        private readonly JsonConverter resourceConverter;
    //    private readonly JsonConverter linksConverter = new LinksConverter();
      //  private readonly JsonConverter embeddedResourceConverter = new EmbeddedResourceConverter();

        public JsonHalMediaTypeFormatter(IHypermediaResolver hypermediaConfiguration)
        {
            if (hypermediaConfiguration == null)
            {
                throw new ArgumentNullException(nameof(hypermediaConfiguration));
            }
            resourceConverter = new ResourceConverter(hypermediaConfiguration);
            Initialize();
        }

        public JsonHalMediaTypeFormatter()
        {
            resourceConverter = new ResourceConverter();
            Initialize();
        }

        public override bool CanReadType(Type type)
        {
            return typeof(Representation).IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(Representation).IsAssignableFrom(type);
        }

        private void Initialize()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/hal+json"));
            SerializerSettings.Converters.Add(linksConverter);
            SerializerSettings.Converters.Add(resourceListConverter);
            SerializerSettings.Converters.Add(resourceConverter);
            SerializerSettings.Converters.Add(embeddedResourceConverter);
            SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
    }
}