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
            CartEntity cartEntity = GetCart(cart.Id);

            foreach (CartItem item in cart.Items)
            {
                var cartItemEntity = new CartItemEntity();
                cartItemEntity.ProductId = item.ProductId;
                cartEntity.Items.Add(cartItemEntity);
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

            return (cartEntity != null) ? GetCartDomain(cartEntity) : CartDomain.Default;
        }

        public CartEntity GetCart(int cartId)
        {
            return Db.Carts.FirstOrDefault(c => c.Id == cartId) ?? new CartEntity();
        }

        private static CartDomain GetCartDomain(CartEntity cartEntity)
        {
            List<CartItem> cartItems = cartEntity.Items.Select(item => new CartItemDomain(item.ProductId)).ToList();
            return new CartDomain(cartEntity.Id, cartEntity.CustomerId, cartItems);
        }
    }
}