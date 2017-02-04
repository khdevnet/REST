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
    }
}