using WatchShop.Domain.Catalog.Extensibility.Entities;

namespace WatchShop.Domain.Catalog.Extensibility
{
    public interface ICatalogAdministration
    {
        void AddProduct(string name, decimal price);

        void UpdateProduct(Product product);

        void RemoveProduct(int productId);
    }
}