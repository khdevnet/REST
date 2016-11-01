using System;
using System.Collections.Generic;
using Hal.Engine.Extensibility;
using Hal.Engine.Extensibility.Dto;

namespace WatchShop.Api.Resource
{
    public class CatalogRepresentation : IListHypermedia<ProductRepresentation>, ILinksHypermedia
    {
        public CatalogRepresentation()
        {
            Links = new List<Link>();
        }

        public IList<Link> Links { get; set; }

        public IList<ProductRepresentation> Items { get; set; }

        public void Bind()
        {
            Links.Add(new Link { Rel = "self", Href = "/catalog" });
            Links.Add(new Link { Rel = "home", Href = "/" });
            Links.Add(new Link { Rel = "cart", Href = "/cart" });
        }
    }
}