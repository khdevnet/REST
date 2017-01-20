using System.Collections.Generic;
using Hal.Engine.Extensibility.Dto;
using Hal.Engine.Extensibility.Hypermedia;

namespace WatchShop.Api.Catalog
{
    public class CatalogRepresentation : IListHypermedia<ILinksHypermedia>, ILinksHypermedia
    {
        public CatalogRepresentation()
        {
            Links = new List<Link>();
        }

        public IList<Link> Links { get; set; }

        public IList<ILinksHypermedia> Items { get; set; }

        public void Bind()
        {
            Links.Add(new Link { Rel = "self", Href = "/catalog/catalog" });
            Links.Add(new Link { Rel = "home", Href = "/" });
            Links.Add(new Link { Rel = "cart", Href = "/cart/cart" });
        }
    }
}