using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class DeliveryUnit
    {
        [Key]
        public long DeliveryUnitId { get; set; }
        public string DeliveryUnitName { get; set; }
    }
}
