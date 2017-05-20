using System.Collections.Generic;
using System.Linq;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Accounts.Extensibility.Entities;
using WatchShop.Domain.Carts.Extensibility.Entities;
using WatchShop.Domain.Common.Extensibility;

namespace WatchShop.Domain.Checkout
{
    internal class CheckoutProcessor : ICheckoutProcessor
    {
        private readonly IShopDataContext dataContext;

        public CheckoutProcessor(IShopDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Process(string customerEmail)
        {
            var cart = dataContext.Carts.GetCart(customerEmail);

            var order = new Order
            {
                CustomerId = dataContext.Customers.GetCustomer(customerEmail).Id
            };

            foreach (CartItem cartItem in cart.Items.ToList())
            {
                AddOrderProduct(order.OrderProducts, cartItem);
            }

            order.Total = cart.GetTotal();
            dataContext.Orders.Add(order);

            dataContext.Carts.Remove(cart);

            dataContext.SaveChanges();
        }

        private static void AddOrderProduct(ICollection<OrderProduct> orderProducts, CartItem cartItem)
        {
            orderProducts.Add(new OrderProduct
            {
                Name = cartItem.Product.Name,
                Price = cartItem.Product.Price,
                ProductId = cartItem.ProductId
            });
        }
    }
}