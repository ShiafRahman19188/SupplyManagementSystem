using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class Yarn
    {
        [Key]
        public int YarnId { get; set; }
        public string? YarnCategory { get; set; }
        public string? YarnShade { get; set; }
        public string? HSCode { get; set; }
    }
}
