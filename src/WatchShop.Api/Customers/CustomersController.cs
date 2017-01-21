using System.Web.Http;
using WatchShop.Domain.Customers;

namespace WatchShop.Api.Customers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public CustomerViewModel GetCustomer(int customerId)
        {
            return customerService.GetRegisteredCustomer(customerId);
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            customerService.RegisterCustomer(customerViewModel);
        }
    }
}