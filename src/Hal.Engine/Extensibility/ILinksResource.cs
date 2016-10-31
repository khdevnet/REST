using System.Collections.Generic;
using Hal.Engine.Extensibility.Dto;

namespace Hal.Engine.Extensibility
{
    public interface ILinksResource
    {
        IList<Link> Links { get; set; }
    }
}