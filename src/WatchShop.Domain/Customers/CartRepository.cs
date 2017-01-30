using System;
using System.Collections.Generic;
using System.Linq;
using CartDomain = WatchShop.Domain.Customers.Cart;
using CartEntity = WatchShop.Domain.Database.Cart;
using CartItemDomain = WatchShop.Domain.Customers.CartItem;
using CartItemEntity = WatchShop.Domain.Database.CartItem;

namespace WatchShop.Domain.Customers
{
    internal class CartRepository : BaseRepository, ICartRepository
    {
        public void Update(CartDomain cart)
        {
            CartEntity cartEntity = GetSingleOrDefaultCart(cart);

            if (cartEntity == null)
            {
                cartEntity = new CartEntity { Customer = Db.Customers.FirstOrDefault(x => x.Id == cart.CustomerId) };
                Db.Carts.Add(cartEntity);
            }

            Db.SaveChanges();
        }

        public void Remove(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public CartDomain GetCart(string customerEmail)
        {
            CartEntity cartEntity = Db.Carts.FirstOrDefault(c => c.Customer.Email == customerEmail);

            if (cartEntity == null)
            {
                cartEntity = new CartEntity
                {
                    CustomerId = Db.Customers.Single(c => c.Email == customerEmail).Id
                };
            }
            return GetCartDomain(cartEntity);
        }

        private static CartDomain GetCartDomain(CartEntity cartEntity)
        {
            List<CartItemDomain> cartItems = cartEntity.Items.Select(item => new CartItemDomain(item.ProductId, item.Quantity)).ToList();
            return new CartDomain(cartEntity.Id, cartEntity.CustomerId, cartItems);
        }

        private CartEntity GetSingleOrDefaultCart(CartDomain cartDomain)
        {
            return Db.Carts.SingleOrDefault(c => c.Id == cartDomain.Id);
        }
    }
}