﻿using System.ComponentModel.DataAnnotations;

namespace SupplyChainManagement.Models
{
    public class Supplier
    {
        [Key]
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactDisplayCode { get; set; }
        
        
    }
}
 