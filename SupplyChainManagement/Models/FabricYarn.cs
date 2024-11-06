
namespace SupplyChainManagement.Models
{
    public class FabricYarn
    {
        public int FabricYarnId { get; set; }
        public int? ItemMasterId { get; set; }
        public int? YarnId { get; set; }
        public virtual ItemMaster ItemMaster { get; set; }
        public virtual Yarn Yarn { get; set; }
    }
}
