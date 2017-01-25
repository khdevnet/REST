using System.Collections.Generic;

namespace WatchShop.Domain.Database
{
    internal class Order
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}