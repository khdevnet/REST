using System.Collections.Generic;
using WatchShop.Domain.Catalogs.Extensibility.Entities;

namespace WatchShop.Domain.Catalogs.Extensibility
{
    public interface ICatalog
    {
        IEnumerable<Product> GetProducts();

        void AddProduct(string name, decimal price);

        void UpdateProduct(Product product);

        void RemoveProduct(int productId);

        bool IsProductExist(int productId);
    }
}