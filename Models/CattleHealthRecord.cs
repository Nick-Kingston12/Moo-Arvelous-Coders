using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class CattleHealthRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }  // Changed from string to int

        public int? CattleId { get; set; }  // Already int

        public DateOnly RecordDate { get; set; }

        public string TreatmentType { get; set; } = null!;
        public string Details { get; set; } = null!;

        public virtual Cattle? Cattle { get; set; }
    }
}
