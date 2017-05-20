using WatchShop.Domain.Catalogs;
using WatchShop.Domain.Catalogs.Extensibility.Entities;

namespace WatchShop.Domain.Accounts.Extensibility.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}