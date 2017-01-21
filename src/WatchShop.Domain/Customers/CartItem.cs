using WatchShop.Domain.Catalog;

namespace WatchShop.Domain.Customers
{
    public class CartItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public Product Product { get; set; }
    }
}