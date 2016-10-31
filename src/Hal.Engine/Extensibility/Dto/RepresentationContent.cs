using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Hal.Engine.Extensibility;

namespace Hal.Engine
{
    public abstract class Representation<TContent> : Representation, IResource<TContent>
    {
        [JsonIgnore]
        private readonly IDictionary<PropertyInfo, object> embeddedResourceProperties = new Dictionary<PropertyInfo, object>();

        public TContent Content
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}