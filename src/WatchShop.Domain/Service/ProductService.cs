using System.Collections.Generic;
using WatchShop.Domain.Database.Model;
using WatchShop.Domain.Extensibility.Repository;
using WatchShop.Domain.Repository;

namespace WatchShop.Domain.Service
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProdutcs()
        {
            using (var productRepository = new ProductRepository())
            {
                return productRepository.GetProdutcs();
            }
        }
    }
}