using System;
using System.Collections.Generic;

namespace WatchShop.Domain.Products
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProdutcs();
    }
}