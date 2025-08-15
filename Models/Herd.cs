using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moo_Arvelous_Coders.Models;

public partial class Herd
{
    [Key]
    public string HerdId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8); // auto-create on model creation


    [Required(ErrorMessage = "Herd name is required.")]
    public string HerdName { get; set; }

    public string? Bull { get; set; } 

    public string? Cattle { get; set; } 

    [Required(ErrorMessage = "Herd size is required.")]
    [Range(1, 1000, ErrorMessage = "Herd size must be a number between 1 and 1000.")]
    public int Herdsize { get; set; }

    public string? FarmId { get; set; }

    public string? FarmerId { get; set; }

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();

    public virtual Farm? Farm { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual ICollection<HerdComment> HerdComments { get; set; }
}
