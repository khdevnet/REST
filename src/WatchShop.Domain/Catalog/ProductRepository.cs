using System.Collections.Generic;
using System.Linq;
using WatchShop.Domain.Catalog.Extensibility;
using WatchShop.Domain.Catalog.Extensibility.Entities;
using WatchShop.Domain.Common;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Catalog
{
    internal class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(IShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public bool IsExist(int productId)
        {
            return context.Products.Any(x => x.Id == productId);
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public void Update(Product product)
        {
            Product productEntity = Single(product.Id);
            productEntity.Name = product.Name;
            productEntity.Price = product.Price;
        }

        public void Remove(int productId)
        {
            context.Products.Remove(Single(productId));
        }

        public Product Single(int productId)
        {
            return context.Products.Single(p => p.Id == productId);
        }
    }
}