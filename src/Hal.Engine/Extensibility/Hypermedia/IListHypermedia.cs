using System.Collections.Generic;

namespace Hal.Engine.Extensibility.Hypermedia
{
    public interface IListHypermedia<TItem> : IHypermedia where TItem : ILinksHypermedia
    {
        IEnumerable<TItem> Items { get; }
    }
}