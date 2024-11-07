using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class ItemGroup
    {
        [Key]
        public int ItemGroupId { get; set; }
        public string? GroupName { get; set; }
    }
}
