using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Moo_Arvelous_Coders.Models;

public partial class MooArvelousDbContext : DbContext
{
    public MooArvelousDbContext()
    {
    }

    public MooArvelousDbContext(DbContextOptions<MooArvelousDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Cattle> Cattles { get; set; }

    public virtual DbSet<CattleHealthRecord> CattleHealthRecords { get; set; }

    public virtual DbSet<CattlePhoto> CattlePhotos { get; set; }

    public virtual DbSet<CattleSaleRecord> CattleSaleRecords { get; set; }

    public virtual DbSet<Farm> Farms { get; set; }

    public virtual DbSet<Farmer> Farmers { get; set; }

    public virtual DbSet<Herd> Herds { get; set; }

    public virtual DbSet<HerdComment> HerdComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NICKKINGSTON\\MSSQLSERVER01;Database=MooArvelousDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.BuyerId).HasName("PK__Buyer__4B81C1CA078A2677");

            entity.ToTable("Buyer");

            entity.HasIndex(e => e.Bidnumber, "UQ__Buyer__218A515C8481D745").IsUnique();

            entity.Property(e => e.BuyerId).HasColumnName("BuyerID");
            entity.Property(e => e.Bemail)
                .HasMaxLength(100)
                .HasColumnName("BEmail");
            entity.Property(e => e.BfirstName)
                .HasMaxLength(50)
                .HasColumnName("BFirstName");
            entity.Property(e => e.Bidnumber)
                .HasMaxLength(20)
                .HasColumnName("BIDNumber");
            entity.Property(e => e.BlastName)
                .HasMaxLength(50)
                .HasColumnName("BLastName");
            entity.Property(e => e.BphoneNumber)
                .HasMaxLength(20)
                .HasColumnName("BPhoneNumber");
            entity.Property(e => e.OrganizationName).HasMaxLength(100);
        });

        modelBuilder.Entity<Cattle>(entity =>
        {
            entity.HasKey(e => e.CattleId).HasName("PK__Cattle__E375C63CBAD731FD");

            entity.ToTable("Cattle");

            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Health).HasMaxLength(100);
            entity.Property(e => e.HerdId).HasColumnName("HerdID");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Farmer).WithMany(p => p.Cattles)
                .HasForeignKey(d => d.FarmerId)
                .HasConstraintName("FK__Cattle__FarmerID__44FF419A");

            entity.HasOne(d => d.Herd).WithMany(p => p.Cattles)
                .HasForeignKey(d => d.HerdId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Cattle__HerdID__440B1D61");
        });

        modelBuilder.Entity<CattleHealthRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__CattleHe__FBDF78C921E20F58");

            entity.ToTable("CattleHealthRecord");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.Details).HasMaxLength(255);
            entity.Property(e => e.TreatmentType).HasMaxLength(50);

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattleHealthRecords)
                .HasForeignKey(d => d.CattleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CattleHea__Cattl__4AB81AF0");
        });

        modelBuilder.Entity<CattlePhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__CattlePh__21B7B5826EA21737");

            entity.ToTable("CattlePhoto");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("PhotoURL");

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattlePhotos)
                .HasForeignKey(d => d.CattleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CattlePho__Cattl__47DBAE45");
        });

        modelBuilder.Entity<CattleSaleRecord>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__CattleSa__1EE3C41F136A9DDC");

            entity.ToTable("CattleSaleRecord");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.BuyerId).HasColumnName("BuyerID");
            entity.Property(e => e.CattleId).HasColumnName("CattleID");
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Buyer).WithMany(p => p.CattleSaleRecords)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__CattleSal__Buyer__52593CB8");

            entity.HasOne(d => d.Cattle).WithMany(p => p.CattleSaleRecords)
                .HasForeignKey(d => d.CattleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CattleSal__Cattl__5070F446");

            entity.HasOne(d => d.Farmer).WithMany(p => p.CattleSaleRecords)
                .HasForeignKey(d => d.FarmerId)
                .HasConstraintName("FK__CattleSal__Farme__5165187F");
        });

        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(e => e.FarmId).HasName("PK__Farm__ED7BBA99F98F561A");

            entity.ToTable("Farm");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.FarmName).HasMaxLength(50);
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Manager).HasMaxLength(50);
            entity.Property(e => e.PriceBought).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Farms)
                .HasForeignKey(d => d.FarmerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Farm__FarmerID__3B75D760");
        });

        modelBuilder.Entity<Farmer>(entity =>
        {
            entity.HasKey(e => e.FarmerId).HasName("PK__Farmer__731B88E8CB2BC6CA");

            entity.ToTable("Farmer");

            entity.HasIndex(e => e.EmailAddress, "UQ__Farmer__49A147408D2FB0FE").IsUnique();

            entity.HasIndex(e => e.Idnumber, "UQ__Farmer__564DB08AE2C54990").IsUnique();

            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Idnumber)
                .HasMaxLength(20)
                .HasColumnName("IDNumber");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Herd>(entity =>
        {
            entity.HasKey(e => e.HerdId).HasName("PK__Herd__0889874A8A2B7728");

            entity.ToTable("Herd");

            entity.Property(e => e.HerdId).HasColumnName("HerdID");
            entity.Property(e => e.Bull).HasMaxLength(50);
            entity.Property(e => e.Cattle).HasMaxLength(50);
            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.HerdName).HasMaxLength(50);

            entity.HasOne(d => d.Farm).WithMany(p => p.Herds)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Herd__FarmID__3E52440B");

            entity.HasOne(d => d.Farmer).WithMany(p => p.Herds)
                .HasForeignKey(d => d.FarmerId)
                .HasConstraintName("FK__Herd__FarmerID__3F466844");
        });

        modelBuilder.Entity<HerdComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__HerdComm__C3B4DFAA66060F54");

            entity.ToTable("HerdComment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CommentDescription).HasMaxLength(255);
            entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
            entity.Property(e => e.HerdId).HasColumnName("HerdID");

            entity.HasOne(d => d.Farmer).WithMany(p => p.HerdComments)
                .HasForeignKey(d => d.FarmerId)
                .HasConstraintName("FK__HerdComme__Farme__5629CD9C");

            entity.HasOne(d => d.Herd).WithMany(p => p.HerdComments)
                .HasForeignKey(d => d.HerdId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__HerdComme__HerdI__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
