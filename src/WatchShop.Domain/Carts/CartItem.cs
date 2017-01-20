using WatchShop.Domain.Catalog;

namespace WatchShop.Domain.Carts
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}