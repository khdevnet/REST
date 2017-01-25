namespace WatchShop.Domain.Customers
{
    public class CartItem
    {
        public CartItem(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; }
    }
}