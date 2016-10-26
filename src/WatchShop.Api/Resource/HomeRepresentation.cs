using System.Collections.Generic;
using Hal.Engine;
using WatchShop.Api.ViewModel;

namespace WatchShop.Api.Resource
{
    public class HomeRepresentation : Representation
    {
        public string Title { get; set; }

        public string Welcome { get; set; }

        protected override void CreateHypermedia()
        {
            Href = "/";
            Links.Add(new Link { Rel = "catalog", Href = "/catalog" });
            Links.Add(new Link { Rel = "cart", Href = "/cart" });
        }
    }
}