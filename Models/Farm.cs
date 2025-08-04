using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Moo_Arvelous_Coders.Models;

public partial class Farm
{
    [Key]
    public string FarmId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8); // auto-create on model creation


    [Required(ErrorMessage = "Farm name is required.")]
    public string FarmName { get; set; } = null!;

    [Required(ErrorMessage = "Location is required.")]
    public string Location { get; set; } = null!;

    [Required(ErrorMessage = "Farm price is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Farm price must be greater than 0.")]
    public decimal PriceBought { get; set; }

    [Required(ErrorMessage = "Farm size is required.")]
    [Range(1, 10000, ErrorMessage = "Farm size must be between 1 and 10,000 hectares.")]
    public double FarmSize { get; set; }

    [Required(ErrorMessage = "Farm manager name is required.")]
    public string Manager { get; set; } = null!;

    public int? FarmerId { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual ICollection<Herd> Herds { get; set; } = new List<Herd>();
}
