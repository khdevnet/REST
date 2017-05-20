using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Accounts.Extensibility.Entities;
using WatchShop.Domain.Common;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Accounts
{
    internal class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(IShopDbContext context) : base(context)
        {
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);
        }

        public Order GetOrder(string customerEmail, int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders(string customerEmail)
        {
            return context.Orders
                .Include(x => x.Id)
                .Include(x => x.OrderProducts)
                .ToList();
        }

        public void Remove(Order order)
        {
            context.Orders.Remove(order);
        }
    }
}