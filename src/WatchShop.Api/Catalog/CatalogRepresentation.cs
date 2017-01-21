using System.Collections.Generic;
using Hal.Engine.Extensibility.Dto;
using Hal.Engine.Extensibility.Hypermedia;

namespace WatchShop.Api.Catalog
{
    public class CatalogRepresentation : IListHypermedia<ILinksHypermedia>, ILinksHypermedia
    {
        public CatalogRepresentation(IEnumerable<ILinksHypermedia> items)
        {
            Links = new List<Link>();
            Items = items;
        }

        public IList<Link> Links { get; set; }

        public IEnumerable<ILinksHypermedia> Items { get; }

        public void Bind()
        {
            Links.Add(new Link { Rel = "self", Href = "/api/catalog" });
            Links.Add(new Link { Rel = "home", Href = "/api/" });
            Links.Add(new Link { Rel = "cart", Href = "/api/cart" });
        }
    }
}