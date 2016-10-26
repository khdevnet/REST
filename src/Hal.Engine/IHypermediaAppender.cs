using System.Collections.Generic;
using Hal.Engine.Interfaces;

namespace Hal.Engine
{
    public interface IHypermediaAppender<T> where T : class, IResource
    {
        void Append(T resource, IEnumerable<Link> configured);
    }
}