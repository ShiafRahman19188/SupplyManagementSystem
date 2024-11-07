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
        
        public DbSet<YarnPOMaster> ItemPOMaster { get; set; }
        public DbSet<YarnPOChild> ItemPODetail { get; set; }

        public DbSet<Yarn> Yarns { get; set; }
        public DbSet<ItemMaster> ItemMasters { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemSubGroup> ItemSubGroups { get; set; }
        public DbSet<BookingMaster> BookingMasters { get; set; }
        public DbSet<BookingChild> BookingChild { get; set; }
        public DbSet<FabricYarn> FabricYarns { get; set; }
        public DbSet<YarnBookingMaster> YarnBookingMasters { get; set; }
        public DbSet<YarnBookingChild> YarnBookingChilds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRDetails>()
                .HasOne(p => p.PurchaseRequisition)
                .WithMany()
                .HasForeignKey(p => p.PurchaseRequisitionPRID);

            

           


        }
    }
}
