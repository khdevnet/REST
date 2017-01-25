using System.Collections.Generic;
using System.Linq;
using ProductDomain = WatchShop.Domain.Catalog.Product;

namespace WatchShop.Domain.Catalog
{
    internal class ProductRepository : BaseRepository, IProductRepository
    {
        public IEnumerable<ProductDomain> GetProdutcs()
        {
            return Db.Products.ToList().Select(x => new ProductDomain(x.Id, x.Name, x.Price));
        }
    }
}