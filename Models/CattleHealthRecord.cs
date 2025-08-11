using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class CattleHealthRecord
{
    public string RecordId { get; set; }

    public string? CattleId { get; set; }

    public DateOnly RecordDate { get; set; }

    public string TreatmentType { get; set; } = null!;

    public string Details { get; set; } = null!;

    public virtual Cattle? Cattle { get; set; }
}
