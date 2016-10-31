using Newtonsoft.Json;

namespace Hal.Engine.Extensibility
{
    public interface IResource<TContent> : IResourceBase
    {
        [JsonProperty("content")]
        TContent Content { get; set; }
    }
}