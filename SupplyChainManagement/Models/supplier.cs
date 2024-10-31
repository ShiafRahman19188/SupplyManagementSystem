using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class supplier
    {
        [Key]
        public Int64 supplierId { get; set; }
        public String? supplierName { get; set; }
    }
}
