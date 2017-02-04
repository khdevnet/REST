using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WatchShop.Domain.Common.Extensibility;

namespace WatchShop.Api.Catalog
{
    public class CatalogController : ApiController
    {
        private readonly IShopDataContext dataContext;

        public CatalogController(IShopDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public CatalogRepresentation Get()
        {
            IEnumerable<ProductRepresentation> products = dataContext.Products
                .GetProducts()
                .Select(product => new ProductRepresentation
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                }).ToList();

            return new CatalogRepresentation(products);
        }

        public IHttpActionResult GetProduct(int id)
        {
            if (dataContext.Products.IsExist(id))
            {
                ProductRepresentation result = dataContext.Products
                .GetProducts()
                .Where(product => product.Id == id)
                .Select(product => new ProductRepresentation
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                }).Single();

                return Ok(result);
            }

            return NotFound();
        }
    }
}