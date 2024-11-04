using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class PRDetails
    {
        [Key]
        public long PRDetailsId { get; set; }  
        public int ItemMasterID { get; set; }
        public int LeadTime { get; set; }
        public string ItemName { get; set; }
        public decimal PRQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ShadeCode { get; set; }
        public string UOM { get; set; }

    }
}
