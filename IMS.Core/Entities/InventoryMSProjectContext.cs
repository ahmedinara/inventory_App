using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class InventoryMSProjectContext : DbContext
    {
        public InventoryMSProjectContext()
        {
        }

        public InventoryMSProjectContext(DbContextOptions<InventoryMSProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Custmer> Custmers { get; set; }
        public virtual DbSet<ItemScanned> ItemScanneds { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MeasuringUnit> MeasuringUnits { get; set; }
        public virtual DbSet<ProductMaster> ProductMasters { get; set; }
        public virtual DbSet<ProductVarient> ProductVarients { get; set; }
        public virtual DbSet<RfIdScannedProduct> RfIdScannedProducts { get; set; }
        public virtual DbSet<ScannedState> ScannedStates { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TransferIn> TransferIns { get; set; }
        public virtual DbSet<TransferInDetail> TransferInDetails { get; set; }
        public virtual DbSet<TransferOut> TransferOuts { get; set; }
        public virtual DbSet<TransferOutDetail> TransferOutDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WebHook> WebHooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Inventory MS- Project;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.ParentId, "IX_Category_ParentId");

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Name_Ar");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Name_En");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.LogoUrl).HasMaxLength(250);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Name_Ar");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Name_En");

                entity.Property(e => e.Website).HasMaxLength(250);
            });

            modelBuilder.Entity<Custmer>(entity =>
            {
                entity.ToTable("Custmer");

                entity.HasIndex(e => e.CreatedBy, "IX_Custmer_CreatedBy");

                entity.HasIndex(e => e.UpdatedBy, "IX_Custmer_UpdatedBy");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.MobileNo).HasMaxLength(100);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Name_Ar");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Name_En");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CustmerCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Custmer_User");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.CustmerUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_Custmer_User1");
            });

            modelBuilder.Entity<ItemScanned>(entity =>
            {
                entity.ToTable("ItemScanned");

                entity.HasIndex(e => e.ProductVarientCode, "IX_RfIdScannedProductDetail_ProductId");

                entity.HasIndex(e => e.StatesId, "IX_RfIdScannedProductDetail_StatesId");

                entity.HasOne(d => d.ProductVarientCodeNavigation)
                    .WithMany(p => p.ItemScanneds)
                    .HasForeignKey(d => d.ProductVarientCode)
                    .HasConstraintName("FK_ItemScanned_Product_Varient");

                entity.HasOne(d => d.Scanned)
                    .WithMany(p => p.ItemScanneds)
                    .HasForeignKey(d => d.ScannedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsScanned_RfIdScannedProduct");

                entity.HasOne(d => d.States)
                    .WithMany(p => p.ItemScanneds)
                    .HasForeignKey(d => d.StatesId)
                    .HasConstraintName("FK_RfIdScannedProductDetail_ScannedStates_StatesId");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Name_Ar");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Name_En");
            });

            modelBuilder.Entity<MeasuringUnit>(entity =>
            {
                entity.ToTable("MeasuringUnit");

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Name_Ar");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Name_En");
            });

            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.ToTable("Product_Master");

                entity.HasIndex(e => e.CategoryId, "IX_Product_Master_CategoryId");

                entity.HasIndex(e => e.CreatedBy, "IX_Product_Master_CreatedBy");

                entity.HasIndex(e => e.LastUpdateBy, "IX_Product_Master_LastUpdateBy");

                entity.HasIndex(e => e.MeasuringUnitId, "IX_Product_Master_MeasuringUnitId");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TitleAr)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Title_Ar");

                entity.Property(e => e.TitleEn)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Title_En");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductMasters)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Master_Category");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductMasterCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Master_User");

                entity.HasOne(d => d.LastUpdateByNavigation)
                    .WithMany(p => p.ProductMasterLastUpdateByNavigations)
                    .HasForeignKey(d => d.LastUpdateBy)
                    .HasConstraintName("FK_Product_Master_User1");

                entity.HasOne(d => d.MeasuringUnit)
                    .WithMany(p => p.ProductMasters)
                    .HasForeignKey(d => d.MeasuringUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Master_MeasuringUnit");
            });

            modelBuilder.Entity<ProductVarient>(entity =>
            {
                entity.ToTable("Product_Varient");

                entity.HasIndex(e => e.ProductId, "IX_Product_Varient_ProductId");

                entity.Property(e => e.VarientCode).IsRequired();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVarients)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Varient_Product_Master");
            });

            modelBuilder.Entity<RfIdScannedProduct>(entity =>
            {
                entity.ToTable("RfIdScannedProduct");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RfIdScannedProducts)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RfIdScannedProduct_User");
            });

            modelBuilder.Entity<ScannedState>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Name_Ar");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Name_En");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");

                entity.HasIndex(e => e.ProductVarientId, "IX_Stock_ProductId");

                entity.HasOne(d => d.ProductVarient)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductVarientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Product_Varient1");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.HasIndex(e => e.CreatedBy, "IX_Supplier_CreatedBy");

                entity.HasIndex(e => e.UpdatedBy, "IX_Supplier_UpdatedBy");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.MobileNo).HasMaxLength(100);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Name_Ar");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Name_En");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SupplierCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplier_User");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.SupplierUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK_Supplier_User1");
            });

            modelBuilder.Entity<TransferIn>(entity =>
            {
                entity.ToTable("TransferIn");

                entity.HasIndex(e => e.CreatedBy, "IX_TransferIn_CreatedBy");

                entity.HasIndex(e => e.DeletedBy, "IX_TransferIn_DeletedBy");

                entity.HasIndex(e => e.SupplierId, "IX_TransferIn_SupplierId");

                entity.HasIndex(e => e.UpdateBy, "IX_TransferIn_UpdateBy");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TransferInCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferIn_User");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TransferInDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_TransferIn_User2");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TransferIns)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferIn_Supplier");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.TransferInUpdateByNavigations)
                    .HasForeignKey(d => d.UpdateBy)
                    .HasConstraintName("FK_TransferIn_User1");
            });

            modelBuilder.Entity<TransferInDetail>(entity =>
            {
                entity.ToTable("TransferInDetail");

                entity.HasIndex(e => e.TransferInId, "IX_TransferInDetail_TransferInId");

                entity.HasOne(d => d.ProductVarient)
                    .WithMany(p => p.TransferInDetails)
                    .HasForeignKey(d => d.ProductVarientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferInDetail_Product_Varient");

                entity.HasOne(d => d.TransferIn)
                    .WithMany(p => p.TransferInDetails)
                    .HasForeignKey(d => d.TransferInId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferInDetail_TransferIn");
            });

            modelBuilder.Entity<TransferOut>(entity =>
            {
                entity.ToTable("TransferOut");

                entity.HasIndex(e => e.CreatedBy, "IX_TransferOut_CreatedBy");

                entity.HasIndex(e => e.CustmerId, "IX_TransferOut_CustmerId");

                entity.HasIndex(e => e.DeletedBy, "IX_TransferOut_DeletedBy");

                entity.HasIndex(e => e.UpdateBy, "IX_TransferOut_UpdateBy");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TransferOutCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferOut_User");

                entity.HasOne(d => d.Custmer)
                    .WithMany(p => p.TransferOuts)
                    .HasForeignKey(d => d.CustmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferOut_Custmer");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.TransferOutDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_TransferOut_User2");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.TransferOutUpdateByNavigations)
                    .HasForeignKey(d => d.UpdateBy)
                    .HasConstraintName("FK_TransferOut_User1");
            });

            modelBuilder.Entity<TransferOutDetail>(entity =>
            {
                entity.ToTable("TransferOutDetail");

                entity.HasIndex(e => e.TransferOutId, "IX_TransferOutDetail_TransferOutId");

                entity.HasOne(d => d.ProductVarient)
                    .WithMany(p => p.TransferOutDetails)
                    .HasForeignKey(d => d.ProductVarientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferOutDetail_Product_Varient");

                entity.HasOne(d => d.TransferOut)
                    .WithMany(p => p.TransferOutDetails)
                    .HasForeignKey(d => d.TransferOutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransferOutDetail_TransferOut");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.CompanyId, "IX_User_CompanyId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FristName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Company");
            });

            modelBuilder.Entity<WebHook>(entity =>
            {
                entity.Property(e => e.Obj).HasColumnName("obj");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
