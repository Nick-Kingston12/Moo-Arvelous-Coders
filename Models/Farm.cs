using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class Farm
{
    public int FarmId { get; set; }

    public string FarmName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public decimal PriceBought { get; set; }

    public double FarmSize { get; set; }

    public string Manager { get; set; } = null!;

    public int? FarmerId { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual ICollection<Herd> Herds { get; set; } = new List<Herd>();
}
