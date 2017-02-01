using System.Collections.Generic;
using Hal.Engine.Extensibility.Dto;
using Hal.Engine.Extensibility.Hypermedia;

namespace WatchShop.Api.Catalog
{
    public class ProductRepresentation : ILinksHypermedia
    {
        public ProductRepresentation()
        {
            Links = new List<Link>();
        }

        public IList<Link> Links { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public void Bind()
        {
            Links.Add(new Link { Rel = "self", Href = $"/api/catalog/product/{Id}" });
            Links.Add(new Link { Rel = "catalog", Href = "/api/catalog" });
        }
    }
}