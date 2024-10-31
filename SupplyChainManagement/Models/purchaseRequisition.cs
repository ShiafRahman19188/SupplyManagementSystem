using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class purchaseRequisition
    {
        [Key]
        public Int64 pr_id { get; set; }
        public string? pr_no { get; set; }
        public DateTime? pr_date { get; set; }
        public DateTime? delivery_date { get; set; }
        public Int64 merchandiserId { get; set; }
        public Int64 supplierId { get; set; }
        public Int64 deliveryUnitId { get; set; }
        
        public merchandiser merchandiser { get; set; }
        public supplier supplier { get; set; }
        public deliveryUnit deliveryUnit { get; set; }
        public List<itemDetails> itemDetails { get; set; }
    }
}
