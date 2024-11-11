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
        public decimal TotalQuantity { get; set; }

    }




}
