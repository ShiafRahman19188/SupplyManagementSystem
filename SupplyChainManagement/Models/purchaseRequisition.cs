using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class PurchaseRequisition
    {
        [Key]
        public long PRID { get; set; }
        public string PRNumber { get; set; }
        public DateTime? PRDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Requisitionar { get; set; }
        public string Supplier { get; set; }
        public string DeliveryUnit { get; set; }
        

        public List<PRDetails> ItemDetails { get; set; }
    }
}
