using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace m0611.Models
{
    public partial class endtest0611Context : DbContext
    {
        public endtest0611Context()
        {
        }

        public endtest0611Context(DbContextOptions<endtest0611Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<CombineDetail> CombineDetails { get; set; } = null!;
        public virtual DbSet<Component> Components { get; set; } = null!;
        public virtual DbSet<CreditcardInfo> CreditcardInfos { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Orderimg> Orderimgs { get; set; } = null!;
        public virtual DbSet<PostAddress> PostAddresses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<TempOrderDetail> TempOrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NASSIM-PET\\SQLEXPRESS;Initial Catalog=endtest0611;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__Account__7ED91AEFB8F67A15");

                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UQ__Account__A9D105342D309331")
                    .IsUnique();

                entity.Property(e => e.EmailId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmailID");

                entity.Property(e => e.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<CombineDetail>(entity =>
            {
                entity.HasKey(e => e.CombineId)
                    .HasName("PK__CombineD__39469304121AC900");

                entity.ToTable("CombineDetail");

                entity.Property(e => e.CombineId)
                    .ValueGeneratedNever()
                    .HasColumnName("CombineID");

                entity.Property(e => e.Cbody)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CBody");

                entity.Property(e => e.Chead)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHead");

                entity.Property(e => e.Clfoot)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLFoot");

                entity.Property(e => e.Clhand)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CLHand");

                entity.Property(e => e.Crfoot)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CRFoot");

                entity.Property(e => e.Crhand)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CRHand");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("Component");

                entity.Property(e => e.ComponentId)
                    .ValueGeneratedNever()
                    .HasColumnName("ComponentID");

                entity.Property(e => e.ComFileName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsSupply).HasColumnName("isSupply");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.ModelType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CreditcardInfo>(entity =>
            {
                entity.HasKey(e => e.CreditCardId)
                    .HasName("PK__Creditca__6EB1F5100768B828");

                entity.ToTable("CreditcardInfo");

                entity.Property(e => e.CreditCardId)
                    .ValueGeneratedNever()
                    .HasColumnName("CreditCardID");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardholderName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(200);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId)
                    .ValueGeneratedNever()
                    .HasColumnName("MaterialID");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.FPermissions).HasColumnName("fPermissions");

                entity.Property(e => e.Info).HasMaxLength(100);

                entity.Property(e => e.IsSupply).HasColumnName("isSupply");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MtrlFileName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.MemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId)
                    .ValueGeneratedNever()
                    .HasColumnName("ModelID");

                entity.Property(e => e.AddTime).HasColumnType("datetime");

                entity.Property(e => e.FPermissions).HasColumnName("fPermissions");

                entity.Property(e => e.Info).HasMaxLength(100);

                entity.Property(e => e.IsSupply).HasColumnName("isSupply");

                entity.Property(e => e.ModelFileName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModelName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModelType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderNotes).HasMaxLength(200);

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.ShippingAddressId).HasColumnName("ShippingAddressID");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderDetailID");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Qty).HasColumnName("QTY");
            });

            modelBuilder.Entity<Orderimg>(entity =>
            {
                entity.HasKey(e => e.ImgId)
                    .HasName("PK__Orderimg__352F5413F0CFDFB1");

                entity.ToTable("Orderimg");

                entity.Property(e => e.ImgId)
                    .ValueGeneratedNever()
                    .HasColumnName("ImgID");

                entity.Property(e => e.FPath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("fPath");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
            });

            modelBuilder.Entity<PostAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PostAddress");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Descript).HasMaxLength(100);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<TempOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK__TempOrde__D3B9D30C3060887F");

                entity.ToTable("TempOrderDetail");

                entity.Property(e => e.OrderDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderDetailID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Qty).HasColumnName("QTY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
