using SupplyChainManagement.Models;

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

}
