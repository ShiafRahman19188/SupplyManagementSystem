using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class Supplier
    {
        [Key]
        public long SupplierId { get; set; }
        public long SupplierName { get; set; }
    }
}
 