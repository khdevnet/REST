using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Customers.CustomerModels
{
    public class CustomerEmailRequestModel
    {
        [Required]
        [EmailAddress]
        [MinLength(4)]
        [MaxLength(256)]
        public string Email { get; set; }
    }
}