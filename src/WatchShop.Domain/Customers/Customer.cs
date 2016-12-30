using System.Collections.Generic;
using WatchShop.Domain.Orders;

namespace WatchShop.Domain.Customers
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public IList<Order> Orders { get; }

        public void Add(Order order)
        {
            Orders.Add(order);
        }
    }
}