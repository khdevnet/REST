using System.Collections.Generic;
using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Catalogs.Extensibility.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}