using Microsoft.AspNetCore.Http;
using Moo_Arvelous_Coders.Models;

namespace Moo_Arvelous_Coders.Models
{
    public class CattleCreateViewModel
    {
        public Cattle Cattle { get; set; } = new Cattle();
        public CattlePhoto Photo { get; set; } = new CattlePhoto();
        public CattleHealthRecord HealthRecord { get; set; } = new CattleHealthRecord();
        public IFormFile? PhotoFile { get; set; }
    }
}
