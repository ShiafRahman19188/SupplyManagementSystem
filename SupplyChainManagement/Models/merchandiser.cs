using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class Merchandiser
    {
        [Key]
        public long MerchandiserId { get; set; }
        public string MerchandiserName { get; set; }
    }
}
