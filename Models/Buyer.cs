using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class Buyer
{
    public string BuyerId { get; set; }

    public string BfirstName { get; set; } = null!;

    public string BlastName { get; set; } = null!;

    public string BphoneNumber { get; set; } = null!;

    public string? Bemail { get; set; }

    public string? Bidnumber { get; set; }

    public string? OrganizationName { get; set; }

    public virtual ICollection<CattleSaleRecord> CattleSaleRecords { get; set; } = new List<CattleSaleRecord>();
}
