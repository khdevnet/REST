using System.Collections.Generic;
using WatchShop.Domain.Database.Model;

namespace WatchShop.Domain.Extensibility.Repository
{
    public interface IProductService
    {
        IEnumerable<Product> GetProdutcs();
    }
}