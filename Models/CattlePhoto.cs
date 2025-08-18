using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moo_Arvelous_Coders.Models;

public partial class CattlePhoto
{
    [Key]
    public string PhotoId { get; set; }

    public string? CattleId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Cattle? Cattle { get; set; }
}
