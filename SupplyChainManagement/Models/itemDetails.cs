using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class ItemDetails
    {
        [Key]
        public long ItemDetailsId { get; set; }
        public string ItemName { get; set; }
        
        public PurchaseRequisition PurchaseRequisition { get; set; }
    }
}
