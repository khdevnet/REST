using System;
using System.Collections.Generic;
using Hal.Engine;
using Hal.Engine.Extensibility;
using Hal.Engine.Extensibility.Dto;

namespace WatchShop.Api.Resource
{
    public class HomeRepresentation : ILinksResource, IRepresentation
    {
        public HomeRepresentation()
        {
            Links = new List<Link>();
        }
        public IList<Link> Links { get; set; }

        public string Title { get; set; }

        public string Welcome { get; set; }
        void IRepresentation.CreateHypermedia()
        {
            Links.Add(new Link { Rel = "self", Href = "/" });
            Links.Add(new Link { Rel = "catalog", Href = "/catalog" });
            Links.Add(new Link { Rel = "cart", Href = "/cart" });
        }
    }
}