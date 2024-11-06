namespace SupplyChainManagement.Models
{
    public class YarnSupplier
    {
        public int YarnSupplierId { get; set; }
        public int YartnId { get; set; }
        public int SupplierId { get; set; }
        public virtual Yarn Yarn { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
