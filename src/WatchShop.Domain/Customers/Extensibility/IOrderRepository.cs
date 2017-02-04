using System.Collections.Generic;
using WatchShop.Domain.Customers.Extensibility.Entities;

namespace WatchShop.Domain.Customers.Extensibility
{
    public interface IOrderRepository
    {
        void Add(Order order);

        void Remove(Order order);

        Order GetOrder(string customerEmail, int orderId);

        IEnumerable<Order> GetOrders(string customerEmail);
    }
}