﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WatchShop.Api.Carts.Models
{
    public class AddCartItemRequestModel
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ProductId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }
    }
}