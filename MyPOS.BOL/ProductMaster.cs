using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyPOS.BOL
{
    public class ProductMaster:BaseEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }


        [ForeignKey("CategoryMaster")]
        public int CategoryId { get; set; } //Foreign key
        public virtual CategoryMaster CategoryMaster { get; set; } //Navigation Property


        [ForeignKey("BrandMaster")]
        public int BrandId { get; set; }
        public virtual BrandMaster BrandMaster { get; set; }


        [ForeignKey("SupplierMaster")]
        public int SupplierId { get; set; }
        public virtual SupplierMaster SupplierMaster { get; set; }
    }
}
