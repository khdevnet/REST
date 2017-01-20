using System.Collections.Generic;
using System.Linq;

namespace WatchShop.Domain.Catalog
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public IEnumerable<Product> GetProdutcs()
        {
            return Db.Products.ToList();
        }
    }
}