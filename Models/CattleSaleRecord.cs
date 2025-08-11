using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class CattleSaleRecord
{
    public string SaleId { get; set; }

    public string? CattleId { get; set; }

    public string? FarmerId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal SalePrice { get; set; }

    public string? BuyerId { get; set; }

    public virtual Buyer? Buyer { get; set; }

    public virtual Cattle? Cattle { get; set; }

    public virtual Farmer? Farmer { get; set; }
}
