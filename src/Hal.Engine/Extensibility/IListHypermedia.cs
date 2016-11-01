using System.Collections.Generic;
using Hal.Engine.Extensibility.Dto;

namespace Hal.Engine.Extensibility
{
    public interface IListHypermedia<TItem> : IHypermedia where TItem : IHypermedia
    {
        IList<TItem> Items { get; set; }
    }
}