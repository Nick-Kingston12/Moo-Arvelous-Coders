using Moo_Arvelous_Coders.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class Herd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HerdId { get; set; }

        [Required]
        public string HerdName { get; set; } = null!;

        public string? Bull { get; set; }
        public string? Cattle { get; set; }

        [Required]
        public int Herdsize { get; set; }

        public int? FarmId { get; set; }
        public int? FarmerId { get; set; }

        public virtual Farm? Farm { get; set; }
        public virtual Farmer? Farmer { get; set; }
        public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();
        public virtual ICollection<HerdComment> HerdComments { get; set; } = new List<HerdComment>();
    }
}

