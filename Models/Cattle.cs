using Moo_Arvelous_Coders.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moo_Arvelous_Coders.Models
{
    public partial class Cattle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CattleId { get; set; }

        public string? Status { get; set; }
        public string? Gender { get; set; }
        public string Breed { get; set; } = null!;
        public int Weight { get; set; }
        public string? Health { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }


        [Display(Name = "Date of Death")]
        [DataType(DataType.Date)]
        public DateOnly? DateOfDeath { get; set; } = null;

        public int? HerdId { get; set; }
        public int? FarmerId { get; set; }

        public virtual Herd? Herd { get; set; }
        public virtual Farmer? Farmer { get; set; }
        public virtual ICollection<CattleHealthRecord> CattleHealthRecords { get; set; } = new List<CattleHealthRecord>();
        public virtual ICollection<CattlePhoto> CattlePhotos { get; set; } = new List<CattlePhoto>();
        public virtual ICollection<CattleSaleRecord> CattleSaleRecords { get; set; } = new List<CattleSaleRecord>();
        
        public Cattle()
        {
            DateOfBirth = DateOnly.FromDateTime(DateTime.Today);
        }
    }
}



