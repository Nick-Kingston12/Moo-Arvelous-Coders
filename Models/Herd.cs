using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class Herd
{
    public int HerdId { get; set; }

    public string HerdName { get; set; } = null!;

    public string Bull { get; set; } = null!;

    public string Cattle { get; set; } = null!;

    public double Herdsize { get; set; }

    public int? FarmId { get; set; }

    public int? FarmerId { get; set; }

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();

    public virtual Farm? Farm { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual ICollection<HerdComment> HerdComments { get; set; } = new List<HerdComment>();
}
