using Moo_Arvelous_Coders.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class Farm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FarmId { get; set; }

        [Required]
        public string FarmName { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PriceBought { get; set; }

        [Required]
        public double FarmSize { get; set; }

        [Required]
        public string Manager { get; set; } = null!;

        public int? FarmerId { get; set; }
        public virtual Farmer? Farmer { get; set; }

        public virtual ICollection<Herd> Herds { get; set; } = new List<Herd>();
    }
}
