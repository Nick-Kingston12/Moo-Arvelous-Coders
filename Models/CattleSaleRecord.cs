using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class CattleSaleRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleId { get; set; }

        public int? CattleId { get; set; }
        public Cattle? Cattle { get; set; }

        public int? FarmerId { get; set; }
        public Farmer? Farmer { get; set; }

        public DateOnly SaleDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal SalePrice { get; set; }

        public int? BuyerId { get; set; }
        public Buyer? Buyer { get; set; }
    }
}
