using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class PurchaseRequisition
    {
        [Key]
        public long PRID { get; set; }
        public string? PRNumber { get; set; }
        public DateTime? PRDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public long MerchandiserID { get; set; }
        public long SupplierId { get; set; }
        public long DeliveryUnitId { get; set; }
        
        public Merchandiser Merchandiser { get; set; }
        public Supplier Supplier { get; set; }
        public DeliveryUnit DeliveryUnit { get; set; }
        public List<ItemDetails> ItemDetails { get; set; }
    }
}
