using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
 
        public class YarnPOMaster
        {
        [Key]
        public int YPOMasterID { get; set; }

        [StringLength(50)]
        public string? PONo { get; set; }
        public DateTime? PODate { get; set; }
        public string? CompanyName { get; set; }
        public string? SupplierName { get; set; }
        public string? Currency { get; set; }
        public DateTime? DeliveryStartDate { get; set; }

       
        public DateTime DeliveryEndDate { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

 
        [StringLength(500)]
        public string? Charges { get; set; }

        public string? CountryOfOrigin { get; set; }
        public bool? TransShipmentAllow { get; set; }
        public decimal? ShippingTolerance { get; set; }
        public string? PortofLoading { get; set; }
        public string? PortofDischarge { get; set; }
        public string? ShipmentMode { get; set; }
        public bool? Approved { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? AddedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [StringLength(100)]
        public string? QuotationRefNo { get; set; }
        public DateTime? QuotationRefDate { get; set; }
        public bool? SupplierAcknowledge { get; set; }
        public string? SupplierAcknowledgeBy { get; set; }
        public DateTime? SupplierAcknowledgeDate { get; set; }
        public bool? SupplierReject { get; set; }
        public string? SupplierRejectBy { get; set; }

        [StringLength(500)]
        public string? SupplierRejectReason { get; set; }

        public DateTime DateAdded { get; set; } = new DateTime(1900, 1, 1);
        public DateTime? DateUpdated { get; set; }

        public List<YarnPOChild>? ItemDetails { get; set; }


    }
}
