namespace SupplyChainManagement.Models
{
    public class BookingChild
    {
        public int BookingChildId { get; set; }
        public int BookingMasterId { get; set; }
        public int ItemMasterId { get; set; }
        public virtual BookingMaster BookingMaster { get; set; }
        public virtual ItemMaster ItemMaster { get; set; }

    }
}
