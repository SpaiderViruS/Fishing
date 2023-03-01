using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Рыбалка.Models
{
    public partial class db_demoexalov7Context : DbContext
    {
        public static db_demoexalov7Context DbContext { get; private set; }

        public db_demoexalov7Context()
        {
        }

        public db_demoexalov7Context(DbContextOptions<db_demoexalov7Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderproduct> Orderproduct { get; set; }
        public virtual DbSet<Pickuppoint> Pickuppoint { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=a678e321r;database=db_demoexalov7", x => x.ServerVersion("8.0.30-mysql")).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.Property(e => e.Idcategory).HasColumnName("idcategory");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.IdCities)
                    .HasName("PRIMARY");

                entity.ToTable("cities");

                entity.Property(e => e.IdCities).HasColumnName("idCities");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Idmanufacturer)
                    .HasName("PRIMARY");

                entity.ToTable("manufacturer");

                entity.Property(e => e.Idmanufacturer).HasColumnName("idmanufacturer");

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasColumnName("manufacturerName")
                    .HasColumnType("varchar(75)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.OrderUserId)
                    .HasName("FK_Order_User_idx");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.OrderPickupPoint)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.OrderUserId).HasColumnName("OrderUserID");

                entity.HasOne(d => d.OrderUser)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderUserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductArticleNumber })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("orderproduct");

                entity.HasIndex(e => e.ProductArticleNumber)
                    .HasName("ProductArticleNumber");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductArticleNumber)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderproduct_ibfk_1");

                entity.HasOne(d => d.ProductArticleNumberNavigation)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.ProductArticleNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orderproduct_ibfk_2");
            });

            modelBuilder.Entity<Pickuppoint>(entity =>
            {
                entity.HasKey(e => e.IdpickupPoint)
                    .HasName("PRIMARY");

                entity.ToTable("pickuppoint");

                entity.HasIndex(e => e.City)
                    .HasName("FK_PickPoint_Cities_idx");

                entity.Property(e => e.IdpickupPoint).HasColumnName("idpickupPoint");

                entity.Property(e => e.Home)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Index)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Pickuppoint)
                    .HasForeignKey(d => d.City)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PickPoint_Cities");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductArticleNumber)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.ProductCategory)
                    .HasName("FK_Product_Category_idx");

                entity.HasIndex(e => e.ProductManufacturer)
                    .HasName("FK_Product_Manufacturer_idx");

                entity.HasIndex(e => e.ProductSupplier)
                    .HasName("FK_Product_Supplier_idx");

                entity.HasIndex(e => e.ProductUnit)
                    .HasName("FK_Product_Unit_idx");

                entity.Property(e => e.ProductArticleNumber)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ProductCost).HasColumnType("decimal(19,4)");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductDiscountMax).HasColumnName("ProductDiscountMAX");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductPhoto)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.ProductCategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.ProductManufacturerNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductManufacturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Manufacturer");

                entity.HasOne(d => d.ProductSupplierNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Supplier");

                entity.HasOne(d => d.ProductUnitNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Unit");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Idstatus)
                    .HasName("PRIMARY");

                entity.ToTable("status");

                entity.Property(e => e.Idstatus).HasColumnName("idstatus");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("statusName")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Idsupplier)
                    .HasName("PRIMARY");

                entity.ToTable("supplier");

                entity.Property(e => e.Idsupplier).HasColumnName("idsupplier");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasColumnName("supplierName")
                    .HasColumnType("varchar(75)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.IdUnit)
                    .HasName("PRIMARY");

                entity.ToTable("unit");

                entity.Property(e => e.IdUnit).HasColumnName("idUnit");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserRole)
                    .HasName("UserRole");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserPatronymic)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
