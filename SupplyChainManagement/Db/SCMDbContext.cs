using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Models;

namespace SupplyChainManagement.Db
{
    public class SCMDbContext : DbContext
    {
        public SCMDbContext(DbContextOptions<SCMDbContext> options) : base(options)
        {

        }

        public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Merchandiser> Merchandisers { get; set; }
        public DbSet<DeliveryUnit> DeliveryUnits { get; set; }
        public DbSet<PRDetails> ItemDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRDetails>()
                .HasOne(p => p.PurchaseRequisition)
                .WithMany()
                .HasForeignKey(p => p.PurchaseRequisitionPRID);

            

           


        }
    }
}
