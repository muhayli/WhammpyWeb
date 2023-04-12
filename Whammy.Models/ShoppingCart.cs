using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Whammy.Models
{
    public class ShoppingCart
    {

        public ShoppingCart()
        {
            Count = 1;
        }
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        [ValidateNever]
        public MenuItem MenuItem { get; set; }
        [Range(1, 100, ErrorMessage = "Please select a count between 1 and 100")]
        public int Count { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey(nameof(AppUserId))]
        [ValidateNever]
        public AppUser AppUser { get; set; }
    }
}

