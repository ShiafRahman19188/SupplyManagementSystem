namespace SupplyChainManagement.Models
{
    public class YarnBookingMaster
    {
        public int YarnBookingMasterId { get; set; }
        public string YarnBookingMasterNo { get; set; }
        public int IsAcknowledge { get; set; }
        public List<YarnBookingChild> yarnBookingChildren { get; set; }
    }
}
