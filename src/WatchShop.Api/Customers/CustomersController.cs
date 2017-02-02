﻿using System.Web.Http;
using WatchShop.Api.Customers.CustomerModels;
using WatchShop.Domain.Customers;
using WatchShop.Domain.Registration;

namespace WatchShop.Api.Customers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRegistration customerRegistration;

        public CustomersController(ICustomerRegistration customerRegistration)
        {
            this.customerRegistration = customerRegistration;
        }

        public Customer GetRegisteredCustomer(string email)
        {
            return customerRegistration.GetRegisteredCustomer(email);
        }

        public void Register(CustomerRegistrationRequestModel customerModel)
        {
            var customer = new Customer
            {
                Email = customerModel.Email,
                Address = customerModel.Address,
                Name = customerModel.Name,
                Phone = customerModel.Phone
            };
            customerRegistration.RegisterCustomer(customer);
        }
    }
}