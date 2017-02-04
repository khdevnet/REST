using System.Web.Http;
using WatchShop.Api.Customers.Models;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Api.Infrastructure.HttpActionResults;
using WatchShop.Domain.Customers;

namespace WatchShop.Api.Customers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRegistration customerRegistration;
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRegistration customerRegistration, ICustomerRepository customerRepository)
        {
            this.customerRegistration = customerRegistration;
            this.customerRepository = customerRepository;
        }

        [HttpPost]
        public IHttpActionResult Register(CustomerRequestModel customer)
        {
            if (customerRegistration.IsCustomerRegistered(customer.Email))
            {
                return new FoundResult($"Customer with email: {customer.Email} already registered!");
            }

            customerRegistration.RegisterCustomer(new Customer
            {
                Email = customer.Email,
                Address = customer.Address,
                Name = customer.Name,
                Phone = customer.Phone
            });

            return Ok(customer.Email);
        }

        [HttpPost]
        [SimpleAuthorize]
        public IHttpActionResult UnRegister(CustomerEmailRequestModel customer)
        {
            if (customerRegistration.IsCustomerRegistered(customer.Email))
            {
                customerRegistration.UnRegisterCustomer(customer.Email);
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        [SimpleAuthorize]
        public IHttpActionResult Update(CustomerRequestModel customerModel)
        {
            if (customerRegistration.IsCustomerRegistered(customerModel.Email))
            {
                var customer = customerRepository.GetCustomer(customerModel.Email);
                customer.Address = customerModel.Address;
                customer.Email = customerModel.Email;
                customer.Name = customerModel.Name;
                customer.Phone = customerModel.Phone;
                customerRepository.SaveChanges();
                return Ok();
            }

            return NotFound();
        }
    }
}