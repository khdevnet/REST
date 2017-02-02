using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Customers.CustomerModels
{
    public class CustomerRegistrationRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }
    }
}