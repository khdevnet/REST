using System.Collections.Generic;

namespace WatchShop.Domain.Customers
{
    public class Cart
    {
        public Cart(int customerId, List<CartItem> items = null)
        {
            CustomerId = customerId;
            Items = items ?? new List<CartItem>();
        }

        protected Cart()
        {
            Items = new List<CartItem>();
        }

        public int CustomerId { get; }

        public List<CartItem> Items { get; }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }
    }
}