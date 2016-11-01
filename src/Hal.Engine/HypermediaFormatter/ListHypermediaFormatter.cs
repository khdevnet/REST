using Hal.Engine.Extensibility;

namespace Hal.Engine.HypermediaFormatter
{
    public class ListHypermediaFormatter : IHypermediaFormatter
    {
        public void Formating(IHypermedia resource)
        {
            var listResource = resource as IListHypermedia<IHypermedia>;
        }
    }
}