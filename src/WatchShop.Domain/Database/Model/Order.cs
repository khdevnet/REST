using System.Collections.Generic;

namespace WatchShop.Domain.Database.Model
{
    public class Order
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}