using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class ItemSubGroup
    {
        [Key]
        public int ItemSubGroupId { get; set; }
        public string? SubGroupName { get; set; }
        
    }
}
