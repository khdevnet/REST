using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WatchShop.Api.Catalog.Models;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Catalogs.Extensibility;
using WatchShop.Domain.Catalogs.Extensibility.Entities;
using WatchShop.Domain.Common.Exceptions;

namespace WatchShop.Api.Catalog
{
    public class CatalogController : ApiController
    {
        private readonly ICatalog catalog;

        public CatalogController(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        public CatalogRepresentation Get()
        {
            IEnumerable<ProductRepresentation> products = catalog.GetProducts()
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
            if (catalog.IsProductExist(id))
            {
                ProductRepresentation result = catalog
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

        [HttpPost]
        [TokenAuthorize]
        public IHttpActionResult AddProduct([FromBody]ProductRequestModel product)
        {
            catalog.AddProduct(product.Name, product.Price);
            return Ok();
        }

        [HttpPut]
        [TokenAuthorize]
        public IHttpActionResult UpdateProduct([FromBody]ProductRequestModel product)
        {
            try
            {
                catalog.UpdateProduct(new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        [TokenAuthorize]
        public IHttpActionResult RemoveProduct([FromBody]ProductIdRequestModel product)
        {
            try
            {
                catalog.RemoveProduct(product.Id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}