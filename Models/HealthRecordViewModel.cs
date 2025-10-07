using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models
{
    public class HealthRecordViewModel
    {
        public int CattleId { get; set; }
        public CattleHealthRecord CattleHealthRecord { get; set; } = new CattleHealthRecord();
        public List<CattleHealthRecord> ExistingRecords { get; set; } = new List<CattleHealthRecord>();
    }
}
