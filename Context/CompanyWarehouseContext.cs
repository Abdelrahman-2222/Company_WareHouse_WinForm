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

            modelBuilder.Entity<ItemUnitOfMeasurement>()
                .HasKey(IUOM => new { IUOM.ItemId, IUOM.UnitOfMeasurementId });

            modelBuilder.Entity<SupplyVoucherList>(SVL =>
            {

                SVL.HasKey(SV => new { SV.SupplyVoucherId, SV.ItemId });

                SVL.Property(SVLE => SVLE.SupplyVoucherListDaysUntilExpiration)
                    .HasComputedColumnSql("DATEDIFF(day, GETDATE(), SupplyVoucherListExpirationDate)");
            });
                

            modelBuilder.Entity<DisbursementVoucherList>()
                .HasKey(DVL => new { DVL.DisbursementVoucherId, DVL.ItemId });

                

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
        public virtual DbSet<ItemUnitOfMeasurement> ItemUnitOfMeasurements { get; set; }
        public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
        public virtual DbSet<TransferOperation> TransferOperations { get; set; }
    }
}
