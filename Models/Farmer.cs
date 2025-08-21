using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Moo_Arvelous_Coders.Models;

public partial class Farmer
{
    public string FarmerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "ID Number is required")]
    [RegularExpression(@"^\d{13}$", ErrorMessage = "ID Number must be exactly 13 digits")]
    public string Idnumber { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Email Address is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string EmailAddress { get; set; } = null!;

    public string Location { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;


    public virtual ICollection<CattleSaleRecord> CattleSaleRecords { get; set; } = new List<CattleSaleRecord>();

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();

    public virtual ICollection<Farm> Farms { get; set; } = new List<Farm>();

    public virtual ICollection<HerdComment> HerdComments { get; set; } = new List<HerdComment>();

    public virtual ICollection<Herd> Herds { get; set; } = new List<Herd>();
}
