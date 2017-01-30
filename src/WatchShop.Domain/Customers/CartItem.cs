namespace WatchShop.Domain.Customers
{
    public class CartItem
    {
        private int quantity;

        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            this.quantity = quantity;
        }

        public int ProductId { get; }

        public int Quantity => quantity;

        public void UpdateQuantity(int qty)
        {
            quantity = qty;
        }
    }
}