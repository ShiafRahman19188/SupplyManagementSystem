using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
 
        public class YarnPOMaster
        {
            [Key]
            public int YPOMasterID { get; set; }


            [StringLength(50)]
            public string PONo { get; set; }


            public DateTime PODate { get; set; }


            public string  CompanyName { get; set; }


            public string SupplierName { get; set; }


            public string Currency { get; set; }

            public DateTime DeliveryStartDate { get; set; }

            [Required]
            public DateTime DeliveryEndDate { get; set; }

            [StringLength(500)]
            public string? Remarks { get; set; }

        

            [Required]
            [StringLength(500)]
            public string Charges { get; set; }

            [Required]
            public int CountryOfOrigin { get; set; }

            [Required]
            public bool TransShipmentAllow { get; set; }

            [Required]
            [Column(TypeName = "decimal(18, 2)")]
            public decimal ShippingTolerance { get; set; }

            public int? PortofLoading { get; set; }

            public int? PortofDischarge { get; set; }

            public int? ShipmentMode { get; set; }

            [Required]
            public bool Approved { get; set; }

            [Required]
            public int ApprovedBy { get; set; }

            public DateTime? ApprovedDate { get; set; }

            [Required]
            public int AddedBy { get; set; }

            public int? UpdatedBy { get; set; }

            [Required]
            public bool SignIn { get; set; }

            public DateTime? SignInDate { get; set; }

            [StringLength(100)]
            public string? QuotationRefNo { get; set; }

            public DateTime? QuotationRefDate { get; set; }

            [Required]
            public int SignInBy { get; set; }

            [Required]
            public bool SupplierAcknowledge { get; set; }

            [Required]
            public int SupplierAcknowledgeBy { get; set; }

            public DateTime? SupplierAcknowledgeDate { get; set; }

            [Required]
            public bool SupplierReject { get; set; }

            [Required]
            public int SupplierRejectBy { get; set; }

            [StringLength(500)]
            public string? SupplierRejectReason { get; set; }

            [Required]
            [Column(TypeName = "datetime")]
            public DateTime DateAdded { get; set; } = new DateTime(1900, 1, 1);

            public DateTime? DateUpdated { get; set; }
        
    }
}
