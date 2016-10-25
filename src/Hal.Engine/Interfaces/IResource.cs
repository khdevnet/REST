using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hal.Engine.Interfaces
{
    public interface IResource
    {
        [JsonIgnore]
        string Rel { get; set; }

        [JsonIgnore]
        string Href { get; set; }

        [JsonIgnore]
        string LinkName { get; set; }

        [JsonProperty("_links")]
        IList<Link> Links { get; set; }
    }
}