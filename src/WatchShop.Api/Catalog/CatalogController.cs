using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WatchShop.Api.Catalog.Models;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Catalog.Extensibility.Entities;
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

        [HttpPost]
        [SimpleAuthorize]
        public IHttpActionResult AddProduct([FromBody]ProductRequestModel product)
        {
            dataContext.Products.Add(product.Name, product.Price);
            dataContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [SimpleAuthorize]
        public IHttpActionResult UpdateProduct([FromBody]ProductRequestModel product)
        {
            if (dataContext.Products.IsExist(product.Id))
            {
                Product productEntity = dataContext.Products.Single(product.Id);
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                dataContext.Products.Update(productEntity);
                dataContext.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        [SimpleAuthorize]
        public IHttpActionResult RemoveProduct([FromBody]ProductIdRequestModel product)
        {
            dataContext.Products.Remove(product.Id);
            dataContext.SaveChanges();
            return Ok();
        }
    }
}