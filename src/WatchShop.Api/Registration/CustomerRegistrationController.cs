using System.Web.Http;
using WatchShop.Api.Customers.CustomerModels;
using WatchShop.Domain.Customers;
using WatchShop.Domain.Registration;

namespace WatchShop.Api.Registration
{
    public class CustomerRegistrationController : ApiController
    {
        private readonly ICustomerRegistration customerRegistration;

        public CustomerRegistrationController(ICustomerRegistration customerRegistration)
        {
            this.customerRegistration = customerRegistration;
        }

        public Customer GetRegisteredCustomer(string email)
        {
            return customerRegistration.GetRegisteredCustomer(email);
        }

        [HttpPost]
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