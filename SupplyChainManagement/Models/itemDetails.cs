using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class itemDetails
    {
        [Key]
        public Int64 itemDetailsId { get; set; }
        public String? itemName { get; set; }
        
        public purchaseRequisition purchaseRequisition { get; set; }
    }
}
