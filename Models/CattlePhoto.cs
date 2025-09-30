using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class CattlePhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhotoId { get; set; }  // Changed from string to int

        public int? CattleId { get; set; }  // Changed from string to int

        public string PhotoUrl { get; set; } = null!;
        public string? Description { get; set; }

        public virtual Cattle? Cattle { get; set; }
    }
}
