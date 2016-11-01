using System.Collections.Generic;
using Hal.Engine.Extensibility;
using Hal.Engine.Extensibility.Dto;

namespace WatchShop.Api.Resource
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

        public void Bind()
        {
            Links.Add(new Link { Rel = "self", Href = $"/products/{Id}" });
        }
    }
}