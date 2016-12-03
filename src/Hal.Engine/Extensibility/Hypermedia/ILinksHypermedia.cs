using System.Collections.Generic;
using Hal.Engine.Extensibility.Dto;

namespace Hal.Engine.Extensibility.Hypermedia
{
    public interface ILinksHypermedia : IHypermedia
    {
        IList<Link> Links { get; set; }
    }
}