using System.Collections.Generic;

namespace WatchShop.Service.Products
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProdutcs();
    }
}