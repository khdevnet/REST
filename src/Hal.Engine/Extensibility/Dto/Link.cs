using System;

namespace Hal.Engine
{
    public class Link
    {
        public Link()
        { }

        public Link(string rel, string href)
        {
            if (string.IsNullOrEmpty(href))
            {
                throw new ArgumentNullException("href");
            }
            Href = href;
            Rel = rel;
        }

        public string Href { get; set; }

        public string Rel { get; set; }
    }
}