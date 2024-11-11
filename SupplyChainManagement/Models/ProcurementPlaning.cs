using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class ProcurementPlaning
    {
        [Key]
        public int ProcurementPlaningId { get; set; }
   
        public int PurchaseRequisitionMasterId { get; set; }
        public int POPath { get; set; }
    }
}
