using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Models;

namespace Moo_Arvelous_Coders.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {        }
        public DbSet<Cattle> Cattle { get; set; }           
        public DbSet<CattlePhoto> CattlePhotos { get; set; } 
        public DbSet<CattleHealthRecord> CattleHealthRecords { get; set; } 
        public DbSet<Farmer> Farmers { get; set; }  
        public DbSet<Herd> Herds { get; set; }
    }
}
