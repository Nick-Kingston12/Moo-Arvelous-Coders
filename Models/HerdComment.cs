using Moo_Arvelous_Coders.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class HerdComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Required]
        public string CommentDescription { get; set; } = null!;

        [Required]
        public int HerdId { get; set; }
        public int? FarmerId { get; set; }

        public virtual Herd? Herd { get; set; }
        public virtual Farmer? Farmer { get; set; }
    }
}
