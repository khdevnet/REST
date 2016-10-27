using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Hal.Engine.Interfaces;

namespace Hal.Engine.JsonConverters
{
    public class ResourceConverter : JsonConverter
    {
        private const StreamingContextStates StreamingContextResourceConverterState = StreamingContextStates.Other;
        private readonly IHypermediaResolver hypermediaConfiguration;

        public ResourceConverter()
        {
        }

        public ResourceConverter(IHypermediaResolver hypermediaConfiguration)
        {
            if (hypermediaConfiguration == null)
            {
                throw new ArgumentNullException(nameof(hypermediaConfiguration));
            }
            this.hypermediaConfiguration = hypermediaConfiguration;
        }

        public static bool IsResourceConverterContext(StreamingContext context)
        {
            return context.Context is HalJsonConverterContext && context.State == StreamingContextResourceConverterState;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var resource = (IResource)value;
            IList<Link> linksBackup = resource.Links;

            if (!linksBackup.Any())
            {
                resource.Links = null; // avoid serialization
            }

            StreamingContext saveContext = serializer.Context;
            serializer.Context = GetResourceConverterContext();
            serializer.Converters.Remove(this);
            serializer.Serialize(writer, resource);
            serializer.Converters.Add(this);
            serializer.Context = saveContext;

            if (!linksBackup.Any())
                resource.Links = linksBackup;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // let exceptions leak out of here so ordinary exception handling in the server or client pipeline can take place
            return CreateResource(JObject.Load(reader), objectType);
        }



        private StreamingContext GetResourceConverterContext()
        {
            var context = (hypermediaConfiguration == null)
                ? new HalJsonConverterContext()
                : new HalJsonConverterContext(hypermediaConfiguration);

            return new StreamingContext(StreamingContextResourceConverterState, context);
        }

        static object ConstructResource(Type resourceType)
        {
            // favor c-tor with zero params, but if it doesn't exist, use c-tor with fewest params and pass all null values
            var ctors = resourceType.GetConstructors();
            ConstructorInfo useThisCtor = null;
            foreach (var ctor in ctors)
            {
                if (ctor.GetParameters().Length == 0)
                {
                    useThisCtor = ctor;
                    break;
                }
                if (useThisCtor == null || useThisCtor.GetParameters().Length > ctor.GetParameters().Length)
                    useThisCtor = ctor;
            }
            if (useThisCtor == null) return null;
            var ctorParams = new object[useThisCtor.GetParameters().Length];
            return useThisCtor.Invoke(ctorParams);
        }

        public override bool CanConvert(Type objectType)
        {
            return IsResource(objectType);
        }

        static bool IsResource(Type objectType)
        {
            return typeof(IResourceBase).IsAssignableFrom(objectType);
        }
    }
}