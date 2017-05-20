using System.Collections.Generic;
using WatchShop.Domain.Carts.Extensibility.Entities;
using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Accounts.Extensibility.Entities
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

        public virtual Cart Cart { get; set; }

        public virtual Identity Identity { get; set; }

        public virtual Token Token { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}