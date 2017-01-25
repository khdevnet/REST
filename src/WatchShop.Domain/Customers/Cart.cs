using System.Collections.Generic;

namespace WatchShop.Domain.Customers
{
    public class Cart
    {
        public Cart(int id, int customerId, List<CartItem> items = null)
        {
            Id = id;
            CustomerId = customerId;
            Items = items ?? new List<CartItem>();
        }

        protected Cart()
        {
        }

        public static Cart Default { get; } = new Cart();

        public int Id { get; }

        public int CustomerId { get; }

        public List<CartItem> Items { get; }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }
    }
}