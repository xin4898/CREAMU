using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CreamMUProduct.Models
{
    public partial class CreamMUTestDBContext : DbContext
    {
        public CreamMUTestDBContext()
        {
        }

        public CreamMUTestDBContext(DbContextOptions<CreamMUTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductComment> ProductComments { get; set; } = null!;
        public virtual DbSet<TEmployee> TEmployees { get; set; } = null!;
        public virtual DbSet<TMember> TMembers { get; set; } = null!;
        public virtual DbSet<TPType> TPTypes { get; set; } = null!;
        public virtual DbSet<TProduct> TProducts { get; set; } = null!;
        public virtual DbSet<TTrackingList> TTrackingLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CreamMUTestDB;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("ProductComment");

                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommentID");

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.Date).HasMaxLength(30);

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<TEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tEmployee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName).HasMaxLength(20);
            });

            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tMember");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<TPType>(entity =>
            {
                entity.HasKey(e => e.PTypeId);

                entity.ToTable("tP_Type");

                entity.Property(e => e.PTypeId).HasColumnName("P_TypeID");

                entity.Property(e => e.TypeDescript)
                    .HasMaxLength(50)
                    .HasColumnName("Type_Descript");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tProduct");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PDescript)
                    .HasMaxLength(500)
                    .HasColumnName("P_Descript");

                entity.Property(e => e.PImages)
                    .HasMaxLength(50)
                    .HasColumnName("P_Images");

                entity.Property(e => e.PInstock).HasColumnName("P_Instock");

                entity.Property(e => e.PName)
                    .HasMaxLength(50)
                    .HasColumnName("P_Name");

                entity.Property(e => e.PPrice)
                    .HasColumnType("money")
                    .HasColumnName("P_Price");

                entity.Property(e => e.PReleaseDate)
                    .HasMaxLength(50)
                    .HasColumnName("P_ReleaseDate");

                entity.Property(e => e.PStatus)
                    .HasMaxLength(20)
                    .HasColumnName("P_Status");

                entity.Property(e => e.PTypeId).HasColumnName("P_TypeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TProducts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_tProduct_tEmployee");

                entity.HasOne(d => d.PType)
                    .WithMany(p => p.TProducts)
                    .HasForeignKey(d => d.PTypeId)
                    .HasConstraintName("FK_tProduct_P_TypeID");
            });

            modelBuilder.Entity<TTrackingList>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ProductId });

                entity.ToTable("tTrackingList");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TrackingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TTrackingLists)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tTrackingList_tMember");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
