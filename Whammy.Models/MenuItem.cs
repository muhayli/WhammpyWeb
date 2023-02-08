using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whammy.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Range(1, 1000, ErrorMessage = "Price should be in range 1-1000")]
        public double Price { get; set; }
        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }
        [ForeignKey(nameof(FoodTypeId))]
        public FoodType FoodType { get; set; } = new();
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();
    }
}

