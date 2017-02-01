using System;
using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Customers
{
    public class CartItemRequestModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ProductId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }
    }
}