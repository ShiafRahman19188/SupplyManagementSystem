namespace SupplyChainManagement.Models
{
    public class ItemMaster
    {
        public int ItemMasterId { get; set; }
        public string? ItemName { get; set; }
        public string? DisplayItemName { get; set; }
        public int ItemGroupId { get; set; }
         public int ItemSubGroupId { get; set; } 
        public virtual ItemGroup ItemGroup { get; set; }
        public virtual ItemSubGroup ItemSubGroup { get; set; }
    }
}
