using System.Collections.Generic;
using System.Linq;
using WatchShop.Domain.Customers;

namespace WatchShop.Domain.Registration
{
    internal class CustomerRegistration : ICustomerRegistration
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerRegistration(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetRegisteredCustomer(string email)
        {
            return customerRepository.GetCustomer(email);
        }

        public IEnumerable<Customer> GetRegisteredCustomers()
        {
            return customerRepository.GetCustomers();
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
            }
        }

        public void UnRegisterCustomer(string email)
        {
            customerRepository.Remove(email);
        }
    }
}