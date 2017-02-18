using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Accounts.Models
{
    public class RegistrationRequestModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(4)]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(256)]
        public string Phone { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(256)]
        public string Address { get; set; }
    }
}