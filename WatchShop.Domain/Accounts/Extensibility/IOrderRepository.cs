using System.Collections.Generic;
using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Accounts.Extensibility
{
    public interface IOrderRepository
    {
        void Add(Order order);

        void Remove(Order order);

        Order GetOrder(string customerEmail, int orderId);

        IEnumerable<Order> GetOrders(string customerEmail);
    }
}