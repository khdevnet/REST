using System;

namespace WatchShop.Domain.Customers
{
    internal class CartRepository : BaseRepository, ICartRepository
    {
        public void Add(int customerId, CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(int customerId)
        {
            throw new NotImplementedException();
        }

        public void Remove(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }
}