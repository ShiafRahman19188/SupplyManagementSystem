using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class PurchaseRequisitionMaster
    {
        [Key]
        public int PurchaseRequisitionMasterId { get; set; }
        public string PRNo { get; set; }
        public DateTime PRDate { get; set; }
        public int ItemYarnId { get; set; }
        public decimal TotalQuantity { get; set; }

    }
}
