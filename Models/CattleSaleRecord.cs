using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class CattleSaleRecord
{
    public int SaleId { get; set; }

    public int? CattleId { get; set; }

    public int? FarmerId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal SalePrice { get; set; }

    public int? BuyerId { get; set; }

    public virtual Buyer? Buyer { get; set; }

    public virtual Cattle? Cattle { get; set; }

    public virtual Farmer? Farmer { get; set; }
}
