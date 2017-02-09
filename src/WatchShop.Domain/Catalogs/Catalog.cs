using System.Collections.Generic;
using WatchShop.Domain.Catalogs.Extensibility;
using WatchShop.Domain.Catalogs.Extensibility.Entities;
using WatchShop.Domain.Common.Exceptions;
using WatchShop.Domain.Common.Extensibility;

namespace WatchShop.Domain.Catalogs
{
    internal class Catalog : ICatalog
    {
        private readonly IShopDataContext dataContext;

        public Catalog(IShopDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddProduct(string name, decimal price)
        {
            dataContext.Products.Add(new Product
            {
                Name = name,
                Price = price
            });
            dataContext.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return dataContext.Products.GetProducts();
        }

        public bool IsProductExist(int productId)
        {
            return dataContext.Products.IsExist(productId);
        }

        public void RemoveProduct(int productId)
        {
            if (dataContext.Products.IsExist(productId))
            {
                dataContext.Products.Remove(productId);
                dataContext.SaveChanges();
            }

            throw new NotFoundException($"{nameof(Product)} with id {productId} not found!");
        }

        public void UpdateProduct(Product product)
        {
            if (dataContext.Products.IsExist(product.Id))
            {
                Product productEntity = dataContext.Products.Single(product.Id);
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                dataContext.Products.Update(productEntity);
                dataContext.SaveChanges();
            }

            throw new NotFoundException($"{nameof(Product)} with id {product.Id} not found!");
        }
    }
}