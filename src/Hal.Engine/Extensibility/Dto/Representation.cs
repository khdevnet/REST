using System.Collections.Generic;

namespace Hal.Engine
{
    public abstract class Representation
    {
        public Representation()
        {
            Links = new List<Link>();
        }

        public IList<Link> Links { get; set; }

        public object Meta { get; set; }

        protected abstract void CreateHypermedia();
    }
}