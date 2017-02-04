using System.Linq;

namespace WatchShop.Domain.Customers
{
    internal class CustomerRegistration : ICustomerRegistration
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerRegistration(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public bool IsCustomerRegistered(string email)
        {
            return customerRepository.GetCustomers().Any(c => c.Email == email);
        }

        public void RegisterCustomer(Customer customer)
        {
            if (!IsCustomerRegistered(customer.Email))
            {
                customerRepository.Add(customer);
                customerRepository.SaveChanges();
            }
        }

        public void UnRegisterCustomer(string email)
        {
            var customer = customerRepository.GetCustomer(email);
            customerRepository.Remove(customer);
            customerRepository.SaveChanges();
        }
    }
}