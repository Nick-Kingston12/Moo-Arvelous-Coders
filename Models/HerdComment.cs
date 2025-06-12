using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class HerdComment
{
    public int CommentId { get; set; }

    public string CommentDescription { get; set; } = null!;

    public int? HerdId { get; set; }

    public int? FarmerId { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual Herd? Herd { get; set; }
}
