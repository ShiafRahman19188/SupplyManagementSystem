using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class merchandiser
    {
        [Key]
        public Int64 merchandiserId { get; set; }
        public String? merchandiserName { get; set; }
    }
}
