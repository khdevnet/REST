using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Hal.Engine.Interfaces;

namespace Hal.Engine
{
    public abstract class Representation<TContent> : IResource<TContent>
    {
        [JsonIgnore]
        private readonly IDictionary<PropertyInfo, object> embeddedResourceProperties = new Dictionary<PropertyInfo, object>();

        protected Representation()
        {
            Links = new List<Link>();
        }

        [JsonIgnore]
        public virtual string Rel { get; set; }

        [JsonIgnore]
        public virtual string Href { get; set; }

        [JsonIgnore]
        public string LinkName { get; set; }

        public IList<Link> Links { get; set; }

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

        public object Meta
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