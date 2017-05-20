using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Identity.Models
{
    public class IdentityRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}