using System.Collections.Generic;
using System.Linq;
using WatchShop.Domain.Database.Model;
using WatchShop.Domain.Extensibility;
using WatchShop.Domain.Extensibility.Repository;

namespace WatchShop.Domain.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public IEnumerable<Product> GetProdutcs()
        {
            return Db.Products.ToList();
        }
    }
}