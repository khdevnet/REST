using System;
using System.Collections.Generic;

namespace Hal.Engine.Comparers
{
    internal sealed class LinkEqualityComparer : IEqualityComparer<Link>
    {
        public bool Equals(Link l1, Link l2)
        {
            return string.Compare(l1.Href, l2.Href, StringComparison.OrdinalIgnoreCase) == 0 &&
                   string.Compare(l1.Name, l2.Name, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public int GetHashCode(Link lnk)
        {
            string str = lnk.Name + "~" + lnk.Href;
            return str.GetHashCode();
        }
    }
}