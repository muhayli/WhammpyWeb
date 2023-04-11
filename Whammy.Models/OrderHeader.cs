using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Whammy.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(AppUser))]
        [ValidateNever]
        public string AppUser { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }
        [Required]
        [Display(Name = "Pick Up Time")]
        public DateTime PickUpTime { get; set; }
        [Required]
        [NotMapped]
        public DateTime PickUpDate { get; set; }
        public string OrderStatus { get; set; }
        public string? Comments { get; set; }
        public string? TransactionId { get; set; }
        [Display(Name = "Pickup Name")]
        public string pickupName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}

