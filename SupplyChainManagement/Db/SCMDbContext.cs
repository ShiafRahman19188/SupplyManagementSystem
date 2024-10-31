using Microsoft.EntityFrameworkCore;
using SupplyChainManagement.Models;

namespace SupplyChainManagement.Db
{
    public class SCMDbContext:DbContext
    {
        public SCMDbContext(DbContextOptions<SCMDbContext> options):base(options)
        {
            
        }

        public DbSet<purchaseRequisition> purchaseRequisitions { get; set; }
        public DbSet<supplier> suppliers { get; set; }
        public DbSet<merchandiser> merchandisers { get; set; }
        public DbSet<deliveryUnit> deliveryUnits { get; set; }
        public DbSet<itemDetails> itemDetails { get; set; }
    }
}
