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
        public string AppUserId { get; set; }
        [ForeignKey(nameof(AppUserId))]
        [ValidateNever]
        public AppUser AppUser { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }
        [Required]
        [Display(Name = "Pick up time")]
        public DateTime PickUpTime { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "Pick up date")]
        public DateTime PickUpDate { get; set; }
        public string OrderStatus { get; set; }
        public string? Comments { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }
        [Required]
        [Display(Name = "Pickup Name")]
        public string pickupName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}

