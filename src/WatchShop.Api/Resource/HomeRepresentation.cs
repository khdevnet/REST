using System.Collections.Generic;
using Hal.Engine;
using WatchShop.Api.ViewModel;

namespace WatchShop.Api.Resource
{
    public class HomeRepresentation : Representation
    {
        public string Title { get; set; }

        public string Welcome { get; set; }

        public IEnumerable<ProductViewModel> BestSellersProducts { get; set; }

        protected override void CreateHypermedia()
        {
            Href = "/";
            Links.Add(new Link { Title = "Products", Href = "/products" });
            Links.Add(new Link { Title = "Cart", Href = "/cart" });
        }
    }
}