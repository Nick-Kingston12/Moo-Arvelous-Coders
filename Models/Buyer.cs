using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class Buyer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuyerId { get; set; }  // Changed from string to int

        public string BfirstName { get; set; } = null!;
        public string BlastName { get; set; } = null!;
        public string BphoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Bemail { get; set; } = null!;

        [Required(ErrorMessage = "ID Number is required")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ID Number must be exactly 13 digits")]
        public string Bidnumber { get; set; } = null!;

        public string? OrganizationName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string BPassword { get; set; } = null!;

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("BPassword", ErrorMessage = "Passwords do not match")]
        public string BConfirmPassword { get; set; } = null!;

        public virtual ICollection<CattleSaleRecord> CattleSaleRecords { get; set; } = new List<CattleSaleRecord>();
    }
}
