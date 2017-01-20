using System.Collections.Generic;

namespace WatchShop.Domain.Catalog
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProdutcs();
    }
}