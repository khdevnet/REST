using System.Web.Http;
using WatchShop.Api.Customers.Models;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Api.Infrastructure.HttpActionResults;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Customers.Extensibility;
using WatchShop.Domain.Customers.Extensibility.Entities;

namespace WatchShop.Api.Customers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRegistration customerRegistration;
        private readonly IShopDataContext dataContext;
        private readonly ICheckoutProcess checkoutProcess;

        public CustomersController(ICheckoutProcess checkoutProcess, ICustomerRegistration customerRegistration, IShopDataContext dataContext)
        {
            this.customerRegistration = customerRegistration;
            this.dataContext = dataContext;
            this.checkoutProcess = checkoutProcess;
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
                var customer = dataContext.Customers.GetCustomer(customerModel.Email);
                customer.Address = customerModel.Address;
                customer.Email = customerModel.Email;
                customer.Name = customerModel.Name;
                customer.Phone = customerModel.Phone;
                dataContext.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        [SimpleAuthorize]
        public IHttpActionResult Checkout()
        {
            checkoutProcess.Checkout(User.Identity.Name);
            return Ok();
        }
    }
}