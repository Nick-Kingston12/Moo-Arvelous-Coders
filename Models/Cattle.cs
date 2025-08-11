using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class Cattle
{
    public string CattleId { get; set; }

    public string? Status { get; set; }

    public string? Gender { get; set; }

    public string Breed { get; set; } = null!;

    public string? Health { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateOnly? DateOfDeath { get; set; }

    public string? HerdId { get; set; }

    public string? FarmerId { get; set; }

    public virtual ICollection<CattleHealthRecord> CattleHealthRecords { get; set; } = new List<CattleHealthRecord>();

    public virtual ICollection<CattlePhoto> CattlePhotos { get; set; } = new List<CattlePhoto>();

    public virtual ICollection<CattleSaleRecord> CattleSaleRecords { get; set; } = new List<CattleSaleRecord>();

    public virtual Farmer? Farmer { get; set; }

    public virtual Herd? Herd { get; set; }
}
