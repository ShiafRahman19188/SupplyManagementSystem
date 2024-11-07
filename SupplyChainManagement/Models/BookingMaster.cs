namespace SupplyChainManagement.Models
{
    public class BookingMaster
    {
        public int BookingMasterId { get; set; }
        public string BookingMasterNo { get; set; }
        public string ExportWorkOrder { get; set; }
        public string StyleNo { get; set; }
        public long SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public List<BookingChild> BookingChild { get; set; }

    }
}
