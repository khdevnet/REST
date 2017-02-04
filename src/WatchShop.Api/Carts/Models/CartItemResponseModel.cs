namespace WatchShop.Api.Carts.Models
{
    public class CartItemResponseModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}