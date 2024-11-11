using SupplyChainManagement.DTO;
using static SupplyChainManagement.Controllers.PurchaseRequisitionController;

public class BookingInfo
{
    public int YBookingID { get; set; }
    public int ExportOrderID { get; set; }
    public int BookingID { get; set; }
    public string FabricBookingNo { get; set; }
    public string YarnBookingNo { get; set; }
    public int BuyerID { get; set; }
    public string BuyerName { get; set; }
    public int BuyerTeamID { get; set; }
    public string StyleNo { get; set; }
}


public class PRPending
{
    public List<BookingInfo> EWOBookings { get; set; }
    public List<BookingInfo> Projections { get; set; }
    public List<BookingInfo> CapacityBase { get; set; }
    public List<PurchaseRequisitionMasterDto> PurchaseRequisitionMasterDtos { get; set; }
}