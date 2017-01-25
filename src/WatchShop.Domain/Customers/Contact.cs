namespace WatchShop.Domain.Customers
{
    public class Contact
    {
        public Contact(string email, string phone, string address)
        {
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string Email { get; }

        public string Phone { get; }

        public string Address { get; }
    }
}