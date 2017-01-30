namespace WatchShop.Domain.Customers
{
    public class CartItem
    {
        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; }

        public int Quantity { get; }
    }
}