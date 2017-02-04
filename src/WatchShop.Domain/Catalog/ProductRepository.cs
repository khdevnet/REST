using System;
using System.Collections.Generic;
using System.Linq;

namespace WatchShop.Domain.Catalog
{
    internal class ProductRepository : RepositoryBase, IProductRepository
    {
        public IEnumerable<Product> GetProdutcs()
        {
            return Db.Products.ToList();
        }

        public bool IsExist(int productId)
        {
            return Db.Products.Any(x => x.Id == productId);
        }
    }
}