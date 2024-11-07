namespace SupplyChainManagement.Models
{
    public class YarnBookingChild
    {
        public int YarnBookingChildId { get; set; }
        public int YarnBookingMasterId { get; set; }
        public int ItemMasterId { get; set; }
        public long Quantity { get; set; }
        public virtual YarnBookingMaster YarnBookingMaster { get; set; }
    }
}
