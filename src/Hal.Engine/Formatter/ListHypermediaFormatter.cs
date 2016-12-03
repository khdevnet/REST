using System.Collections.Generic;
using Hal.Engine.Extensibility.Formatter;
using Hal.Engine.Extensibility.Hypermedia;

namespace Hal.Engine.Formatter
{
    public class ListHypermediaFormatter : IHypermediaFormatter
    {
        private readonly List<IHypermediaFormatter> linkHypermediaFormatter =
            new List<IHypermediaFormatter> {
                new HypermediaFormatter(),
                new LinkHypermediaFormatter()
            };

        public void Formating(IHypermedia resource)
        {
            var listResource = (IListHypermedia<ILinksHypermedia>)resource;
            foreach (var item in listResource.Items)
            {
                linkHypermediaFormatter.ForEach(x=>x.Formating(item));
            }
        }
    }
}