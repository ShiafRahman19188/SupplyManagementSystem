using SupplyChainManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.DTO
{
    public class BookingInfoDto
    {


        public int BookingMasterId { get; set; }
        public string BookingMasterNo { get; set; }
        public string ExportWorkOrder { get; set; }
        public string StyleNo { get; set; }
        public string Fabric { get; set; }
        
        public string SupplierName { get; set; }
        public List<YarnInfo> Yarns { get; set; } = new List<YarnInfo>();


    }

    public class YarnInfo
    {
        public int YarnId { get; set; }
        public string Yarn { get; set; }
    }

    public class SaveYarnRequest
    {
        public int BookingMasterId { get; set; }
        public List<YarnDto> Yarns { get; set; }
    }

    public class YarnDto
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
        public string PoQuantity { get; set; }
        public string Uom { get; set; }
    }

    public class YarnBookingMasterDto
    {
        public int YarnBookingMasterId { get; set; }
        public string YarnBookingMasterNo { get; set; }
        public string FabricName { get; set; }
        public string YarnName { get; set; }
        public int IsAcknowledge { get; set; }
        public int FabricId { get; set; }
        public int YarnId { get; set; }
        public List<YarnBookingChildDto> yarnBookingChildren { get; set; }
    }

    public class YarnBookingChildDto
    {
        public int YarnBookingChildId { get; set; }
        public int YarnBookingMasterId { get; set; }
        public int ItemMasterId { get; set; }
        public long Quantity { get; set; }
        public string YarnName { get; set; }
        public decimal TotalQuantity { get; set; }
        public virtual YarnBookingMaster YarnBookingMaster { get; set; }
        public List<YarnBookingDetailsDto> yarnBookingDetails { get; set; }=new List<YarnBookingDetailsDto>();

    }

    public class YarnBookingDetailsDto
    {
        public int YarnBookingMasterId { get; set; }
        public string YarnBookingMasterNo { get; set; }
        public int FabricId { get; set; }
        public string Fabric { get; set; }
        public decimal Quantity { get; set; }
    }

    public class PurchaseRequisitionMasterDto
    {
        [Key]
        public int PurchaseRequisitionMasterId { get; set; }
        public string PRNo { get; set; }
        public DateTime PRDate { get; set; }
        public int ItemYarnId { get; set; }
        public string ItemName { get; set; }
        public string BookingMasterNo { get; set; }
        public decimal TotalQuantity { get; set; }

    }

    public class ItemMasterPODto
    {
        [Key]
        public int YPOMasterID { get; set; }

        [StringLength(50)]
        public string PONo { get; set; }
        public DateTime PODate { get; set; }
        public string CompanyName { get; set; }
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
        public string CountryOfOrigin { get; set; }
        public bool TransShipmentAllow { get; set; }
        public decimal ShippingTolerance { get; set; }
        public string PortofLoading { get; set; }
        public string PortofDischarge { get; set; }
        public string ShipmentMode { get; set; }
        public bool Approved { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int AddedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [StringLength(100)]
        public string? QuotationRefNo { get; set; }
        public DateTime? QuotationRefDate { get; set; }
        public bool SupplierAcknowledge { get; set; }
        public string SupplierAcknowledgeBy { get; set; }

        public DateTime? SupplierAcknowledgeDate { get; set; }
        public bool SupplierReject { get; set; }
        public string SupplierRejectBy { get; set; }
        [StringLength(500)]
        public string? SupplierRejectReason { get; set; }
        public DateTime DateAdded { get; set; } = new DateTime(1900, 1, 1);

        public DateTime? DateUpdated { get; set; }
        public string ItemName { get; set; }
        public List<YarnPOChild> ItemDetails { get; set; }

    }


    public class ProcurementLandingDto
    {
        public int YarnId { get; set; }
        public string YarnName { get; set; }
        public decimal TotalQuantity { get; set; }
        public List<ProcurementChildDto> ProcurementChildren { get; set; }
    }
    public class ProcurementDto
    {
        public int YarnBookingMasterId { get; set; }
        public string YarnBookingMasterNo { get; set; }
        public string FabricName { get; set; }
        public string YarnName { get; set; }
        public int YarnId { get; set; }
        public List<ProcurementChildDto> yarnBookingChildren { get; set; }
    }
    public class ProcurementChildDto
    {
        public string TNASlab { get; set; }
        public int PurchaseRequisitionMasterId { get; set; }
        public string PRNo { get; set; }
        public string PathOfPO { get; set; }
        public decimal ROLQuantity { get; set; }
        public decimal EwoQuantity { get; set; }
        public decimal ProjectionQuantity { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal FreeStock { get; set; }
        public decimal FreePipeLineStock { get; set; }
        public decimal FreeTransitStock { get; set; }
        public decimal FreePhysicalStock { get; set; }
        public decimal SuggestedStoreRequisition { get; set; }
        public decimal SuggestedPurchaseQuantity { get; set; }
        public decimal PurchaseOrderQuantity { get; set; }
    }
}
