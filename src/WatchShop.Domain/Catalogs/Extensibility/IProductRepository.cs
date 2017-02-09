using System.Collections.Generic;
using WatchShop.Domain.Catalogs.Extensibility.Entities;

namespace WatchShop.Domain.Catalogs.Extensibility
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        bool IsExist(int productId);

        Product Single(int productId);

        void Add(Product product);

        void Update(Product product);

        void Remove(int productId);
    }
}