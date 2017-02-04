using System.Collections.Generic;

namespace WatchShop.Domain.Customers.Extensibility.Entities
{
    public class Order
    {
        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }

        public int Id { get; set; }

        public decimal Total { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}