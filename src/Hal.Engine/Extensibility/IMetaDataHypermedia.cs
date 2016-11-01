namespace Hal.Engine.Extensibility
{
    public interface IMetadataHypermedia : IHypermedia
    {
        object Metadata { get; set; }
    }
}