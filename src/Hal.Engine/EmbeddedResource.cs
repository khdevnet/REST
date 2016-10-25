using System.Collections.Generic;
using Hal.Engine.Interfaces;

namespace Hal.Engine
{
    internal class EmbeddedResource
    {
        public EmbeddedResource()
        {
            Resources = new List<IResource>();
        }

        public bool IsSourceAnArray { get; set; }
        public IList<IResource> Resources { get; private set; }
    }
}