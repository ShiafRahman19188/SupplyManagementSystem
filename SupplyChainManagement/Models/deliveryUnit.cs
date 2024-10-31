using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class deliveryUnit
    {
        [Key]
        public Int64 deliveryUnitId { get; set; }
        public String? deliveryUnitName { get; set; }
    }
}
