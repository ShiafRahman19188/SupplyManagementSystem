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
        public long? PurchaseRequisitionPRID { get; set; }


        public virtual PurchaseRequisition PurchaseRequisition { get; set; }


    }

    public class ItemInsight
    {
        public decimal POQty { get; set; }
        public decimal Rate { get; set; }
        public string QuotationRefNo { get; set; }
        public string CountryName { get; set; }
        public string SupplierName { get; set; }
    }
}
