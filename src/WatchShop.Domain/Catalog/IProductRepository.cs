using System;
using System.Collections.Generic;

namespace WatchShop.Domain.Catalog
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProdutcs();
    }
}