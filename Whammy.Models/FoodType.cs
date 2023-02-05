using System;
using System.ComponentModel.DataAnnotations;

namespace Whammy.Models;

public class FoodType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}