using System;
using System.Collections.Generic;
using WatchShop.Domain.Database.Model;

namespace WatchShop.Domain.Extensibility.Repository
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProdutcs();
    }
}