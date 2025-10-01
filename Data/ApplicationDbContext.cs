using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moo_Arvelous_Coders.Models;

namespace Moo_Arvelous_Coders.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // App tables
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Cattle> Cattle { get; set; }
        public DbSet<CattleHealthRecord> CattleHealthRecords { get; set; }
        public DbSet<CattlePhoto> CattlePhotos { get; set; }
        public DbSet<CattleSaleRecord> CattleSaleRecords { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Herd> Herds { get; set; }
        public DbSet<HerdComment> HerdComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Must call first for Identity

            // Farmer
            modelBuilder.Entity<Farmer>(entity =>
            {
                entity.HasKey(e => e.FarmerId);
                entity.HasIndex(e => e.EmailAddress).IsUnique();
                entity.HasIndex(e => e.Idnumber).IsUnique();
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.EmailAddress).HasMaxLength(100);
                entity.Property(e => e.Idnumber).HasMaxLength(20);
                entity.Property(e => e.Location).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            // Farm
            modelBuilder.Entity<Farm>(entity =>
            {
                entity.HasKey(e => e.FarmId);
                entity.Property(e => e.FarmName).HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(100);
                entity.Property(e => e.Manager).HasMaxLength(50);

                entity.HasOne(d => d.Farmer)
                      .WithMany(p => p.Farms)
                      .HasForeignKey(d => d.FarmerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Herd
            modelBuilder.Entity<Herd>(entity =>
            {
                entity.HasKey(e => e.HerdId);
                entity.Property(e => e.HerdName).HasMaxLength(50);
                entity.Property(e => e.Bull).HasMaxLength(50);
                entity.Property(e => e.Cattle).HasMaxLength(50);

                entity.HasOne(d => d.Farm)
                      .WithMany(p => p.Herds)
                      .HasForeignKey(d => d.FarmId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Farmer)
                      .WithMany(p => p.Herds)
                      .HasForeignKey(d => d.FarmerId);
            });

            // Cattle
            modelBuilder.Entity<Cattle>(entity =>
            {
                entity.HasKey(e => e.CattleId);
                entity.Property(e => e.Breed).HasMaxLength(50);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.Health).HasMaxLength(100);
                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Farmer)
                      .WithMany(p => p.Cattles)
                      .HasForeignKey(d => d.FarmerId);

                entity.HasOne(d => d.Herd)
                      .WithMany(p => p.Cattles)
                      .HasForeignKey(d => d.HerdId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // HerdComment
            modelBuilder.Entity<HerdComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);
                entity.Property(e => e.CommentDescription).HasMaxLength(255);

                entity.HasOne(d => d.Farmer)
                      .WithMany(p => p.HerdComments)
                      .HasForeignKey(d => d.FarmerId);

                entity.HasOne(d => d.Herd)
                      .WithMany(p => p.HerdComments)
                      .HasForeignKey(d => d.HerdId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // CattleSaleRecord
            modelBuilder.Entity<CattleSaleRecord>(entity =>
            {
                entity.HasKey(e => e.SaleId);
                entity.Property(e => e.SalePrice).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Buyer)
                      .WithMany(p => p.CattleSaleRecords)
                      .HasForeignKey(d => d.BuyerId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Cattle)
                      .WithMany(p => p.CattleSaleRecords)
                      .HasForeignKey(d => d.CattleId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Farmer)
                      .WithMany(p => p.CattleSaleRecords)
                      .HasForeignKey(d => d.FarmerId);
            });
        }
    }
}
