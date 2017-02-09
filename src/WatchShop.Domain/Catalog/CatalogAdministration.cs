using WatchShop.Domain.Catalog.Extensibility;
using WatchShop.Domain.Catalog.Extensibility.Entities;
using WatchShop.Domain.Common.Exceptions;
using WatchShop.Domain.Common.Extensibility;

namespace WatchShop.Domain.Catalog
{
    internal class CatalogAdministration : ICatalogAdministration
    {
        private readonly IShopDataContext dataContext;

        public CatalogAdministration(IShopDataContext dataContext)
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