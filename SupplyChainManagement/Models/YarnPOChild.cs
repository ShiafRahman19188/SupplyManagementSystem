using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class YarnPOChild
    {
        [Key]
        public int YPOChildID { get; set; }

        [Required]
        public int YPOMasterID { get; set; }

        [Required]
        [Column("ItemMasterID", TypeName = "int")]
        public int ItemMasterID { get; set; }

        [Required]
        public int UnitName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PoQty { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PIValue { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }

        [StringLength(1000)]
        public string? YarnLotNo { get; set; }

        [StringLength(50)]
        public string? HSCode { get; set; }

        [StringLength(100)]
        public string? YarnShade { get; set; }

        [StringLength(100)]
        public string? BookingNo { get; set; }

        [Required]
        public bool ReceivedCompleted { get; set; }

        public DateTime? ReceivedDate { get; set; }
    }

    public class YarnPOChildDetails
    {
        public int YarnPOChildDetailsID { get; set; }
        public int  PRID { get; set; }
        public int YPOChildID { get; set; }
        public decimal PRQty { get; set; }

    }
}