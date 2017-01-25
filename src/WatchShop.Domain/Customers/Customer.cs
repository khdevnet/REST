namespace WatchShop.Domain.Customers
{
    public class Customer
    {
        public Customer(int id, string name, Contact contacts, Cart cart)
        {
            Id = id;
            Name = name;
            Cart = cart;
            Contacts = contacts;
        }

        public int Id { get; }

        public string Name { get; }

        public Contact Contacts { get; }

        public Cart Cart { get; }
    }
}