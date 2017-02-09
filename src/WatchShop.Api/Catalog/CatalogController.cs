using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WatchShop.Api.Catalog.Models;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Catalog.Extensibility;
using WatchShop.Domain.Catalog.Extensibility.Entities;
using WatchShop.Domain.Common.Exceptions;
using WatchShop.Domain.Common.Extensibility;

namespace WatchShop.Api.Catalog
{
    public class CatalogController : ApiController
    {
        private readonly IShopDataContext dataContext;
        private readonly ICatalogAdministration catalogAdministration;

        public CatalogController(IShopDataContext dataContext, ICatalogAdministration catalogAdministration)
        {
            this.dataContext = dataContext;
            this.catalogAdministration = catalogAdministration;
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

        [HttpPost]
        [SimpleAuthorize]
        public IHttpActionResult AddProduct([FromBody]ProductRequestModel product)
        {
            catalogAdministration.AddProduct(product.Name, product.Price);
            return Ok();
        }

        [HttpPut]
        [SimpleAuthorize]
        public IHttpActionResult UpdateProduct([FromBody]ProductRequestModel product)
        {
            try
            {
                catalogAdministration.UpdateProduct(new Product
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
        [SimpleAuthorize]
        public IHttpActionResult RemoveProduct([FromBody]ProductIdRequestModel product)
        {
            try
            {
                catalogAdministration.RemoveProduct(product.Id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}