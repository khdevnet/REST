using System;
using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Customers.Models
{
    public class CartItemProductRequestModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ProductId { get; set; }
    }
}