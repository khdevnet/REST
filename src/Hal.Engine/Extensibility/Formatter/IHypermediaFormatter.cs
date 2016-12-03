using Hal.Engine.Extensibility.Hypermedia;

namespace Hal.Engine.Extensibility.Formatter
{
    public interface IHypermediaFormatter
    {
        void Formating(IHypermedia resource);
    }
}