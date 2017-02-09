using System.Collections.Generic;
using WatchShop.Domain.Catalog.Extensibility.Entities;

namespace WatchShop.Domain.Catalog.Extensibility
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