using System;
using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Customers.CartModels
{
    public class ProductCartItemRequestModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ProductId { get; set; }
    }
}