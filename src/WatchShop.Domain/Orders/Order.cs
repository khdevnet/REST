using System.Collections.Generic;

namespace WatchShop.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}