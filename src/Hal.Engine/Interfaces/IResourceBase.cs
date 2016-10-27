using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hal.Engine.Interfaces
{
    public interface IResourceBase
    {
        [JsonProperty("links")]
        IList<Link> Links { get; set; }

        [JsonProperty("meta")]
        object Meta { get; set; }
    }
}