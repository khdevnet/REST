using System.Collections.Generic;
using Hal.Engine.Extensibility.Dto;
using Hal.Engine.Extensibility.Hypermedia;

namespace WatchShop.Api.Resource
{
    public class HomeRepresentation : ILinksHypermedia
    {
        public HomeRepresentation()
        {
            Links = new List<Link>();
        }

        public IList<Link> Links { get; set; }

        public string Title { get; set; }

        public string Welcome { get; set; }

        public void Bind()
        {
            Links.Add(new Link { Rel = "self", Href = "/" });
            Links.Add(new Link { Rel = "catalog", Href = "/catalog" });
            Links.Add(new Link { Rel = "cart", Href = "/cart" });
        }
    }
}