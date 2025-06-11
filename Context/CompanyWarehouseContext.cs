using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyForm.Entities;
using CompnayForm.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompnayForm.Context
{
    public class CompanyWarehouseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Build configuration to read appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get the connection string
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Configure DbContext to use SQL Server with the connection string
            optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure();
            });

            base.OnConfiguring(optionsBuilder);
        }

        // Enforce Validation -> Constraints
        public override int SaveChanges()
        {
            var Entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Modified ||
                                 e.State == EntityState.Added
                           select e.Entity;
            foreach (var Entity in Entities)
            {
                ValidationContext validationContext = new ValidationContext(Entity);
                Validator.ValidateObject(Entity, validationContext, true);
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.ItemCode)
                .IsUnique();

            modelBuilder.Entity<SupplyVoucher>()
                .HasIndex(S => S.SupplyVoucherNumber)
                .IsUnique();
            
            modelBuilder.Entity<DisbursementVoucher>()
                .HasIndex(D => D.DisbursementVoucherNumber)
                .IsUnique();

            //modelBuilder.Entity<ItemUnitOfMeasurement>()
            //    .HasKey(IUOM => new { IUOM.ItemId, IUOM.UnitOfMeasurementId });

            modelBuilder.Entity<SupplyVoucherList>(SVL =>
            {

                SVL.HasKey(SV => new { SV.SupplyVoucherId, SV.ItemId });

                SVL.Property(SVLE => SVLE.SupplyVoucherListDaysUntilExpiration)
                    .HasComputedColumnSql("DATEDIFF(day, GETDATE(), SupplyVoucherListExpirationDate)");

                SVL.HasOne(svl => svl.Item)
                    .WithMany(i => i.SupplyVoucherLists)
                    .HasForeignKey(svl => svl.ItemId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
                

            modelBuilder.Entity<DisbursementVoucherList>()
                .HasKey(DVL => new { DVL.DisbursementVoucherId, DVL.ItemId });

            modelBuilder.Entity<DisbursementVoucherList>()
                .HasOne(dvl => dvl.Item)
                .WithMany(i => i.DisbursementVoucherLists)
                .HasForeignKey(dvl => dvl.ItemId)
                .OnDelete(DeleteBehavior.Restrict); // Changed from Cascade to Restrict


            modelBuilder.Entity<TransferOperation>(TO =>
            {
                TO.HasOne(TF => TF.FromWarehouse)
                    .WithMany()
                    .HasForeignKey(TF => TF.FromWarehouseId)
                    .OnDelete(DeleteBehavior.Restrict);

                TO.HasOne(Tt => Tt.ToWarehouse)
                    .WithMany()
                    .HasForeignKey(Tt => Tt.ToWarehouseId)
                    .OnDelete(DeleteBehavior.Restrict);

                TO.HasIndex(t => t.TransferOperationNumber)
                    .IsUnique();
            }
                );

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            //// Warehouse ownership
            //modelBuilder.Entity<Warehouse>()
            //    .HasOne<AppUser>()
            //    .WithMany()
            //    .HasForeignKey(w => w.OwnerId)
            //    .OnDelete(DeleteBehavior.SetNull);

            // Customer user association
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<Customer>(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Supplier user association
            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Supplier>(s => s.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // OR for Option B
            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Owner)
                .WithMany()
                .HasForeignKey(w => w.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Add to your OnModelCreating method
            modelBuilder.Entity<CustomerOwnerRelationship>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerOwnerRelationship>()
                .HasOne(r => r.Owner)
                .WithMany()
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SupplierOwnerRelationship>()
                .HasOne(r => r.Supplier)
                .WithMany()
                .HasForeignKey(r => r.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SupplierOwnerRelationship>()
                .HasOne(r => r.Owner)
                .WithMany()
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Recipient)
                .WithMany()
                .HasForeignKey(n => n.RecipientUserId)
                .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DisbursementVoucher> DisbursementVouchers { get; set; }
        public virtual DbSet<DisbursementVoucherList> DisbursementVoucherLists { get; set; }
        public virtual DbSet<SupplyVoucher> SupplyVouchers { get; set; }
        public virtual DbSet<SupplyVoucherList> SupplyVoucherLists { get; set; }
        //public virtual DbSet<ItemUnitOfMeasurement> ItemUnitOfMeasurements { get; set; }
        //public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public virtual DbSet<TransferOperation> TransferOperations { get; set; }
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }

        public virtual DbSet<SupplierOwnerRelationship> SupplierOwnerRelationships { get; set; }

        public virtual DbSet<CustomerOwnerRelationship> CustomerOwnerRelationships { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        //public virtual DbSet<MyEnum> Enums { get; set; }

    }
}
