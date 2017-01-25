namespace WatchShop.Domain.Catalog
{
    public class Product
    {
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public int Id { get; }

        public string Name { get; }

        public decimal Price { get; }
    }
}