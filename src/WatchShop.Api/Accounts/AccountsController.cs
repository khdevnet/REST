using System.Web.Http;
using WatchShop.Api.Accounts.Models;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Api.Infrastructure.HttpActionResults;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Api.Accounts
{
    public class AccountsController : ApiController
    {
        private readonly IAccount account;

        public AccountsController(IAccount account)
        {
            this.account = account;
        }

        [HttpPost]
        public IHttpActionResult Register(CustomerRequestModel customer)
        {
            if (account.IsRegistered(customer.Email))
            {
                return new FoundResult($"Customer with email: {customer.Email} already registered!");
            }

            account.Register(new Customer
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
            if (account.IsRegistered(customer.Email))
            {
                account.UnRegister(customer.Email);
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        [SimpleAuthorize]
        public IHttpActionResult Update(CustomerRequestModel customerModel)
        {
            if (account.IsRegistered(customerModel.Email))
            {
                account.Update(new Customer
                {
                    Address = customerModel.Address,
                    Email = customerModel.Email,
                    Name = customerModel.Name,
                    Phone = customerModel.Phone
                });
                return Ok();
            }

            return NotFound();
        }
    }
}