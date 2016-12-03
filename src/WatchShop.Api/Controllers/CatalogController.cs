using Hal.Engine.Extensibility;
using Hal.Engine.Extensibility.Hypermedia;
using System.Collections.Generic;
using System.Web.Http;
using WatchShop.Api.Resource;

namespace WatchShop.Api.Controllers
{
    public class CatalogController : ApiController
    {
        // GET Home
        public CatalogRepresentation Get()
        {
            var catalog = new CatalogRepresentation
            {
                Items = new List<ILinksHypermedia>
                {
                    new ProductRepresentation
                    {
                        Id = 1,
                        Name = "Product 1"
                    },
                    new ProductRepresentation
                    {
                        Id = 2,
                        Name = "Product 2"
                    },
                    new ProductRepresentation
                    {
                        Id = 3,
                        Name = "Product 3"
                    }
                }
            };
            return catalog;
        }

        // GET Home
        [HttpGet]
        public ProductRepresentation GetProduct(int id)
        {
            return new ProductRepresentation
            {
                Id = id,
                Name = "Product 1"
            };
        }
    }
}