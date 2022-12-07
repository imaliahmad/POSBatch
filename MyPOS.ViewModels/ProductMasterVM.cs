using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPOS.ViewModels
{
    public class ProductMasterVM : BaseEntityVM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }


        public int CategoryId { get; set; } //Foreign key
        public virtual CategoryMasterVM CategoryMaster { get; set; } //Navigation Property


        public int BrandId { get; set; }
        public virtual BrandMasterVM BrandMaster { get; set; }


        public int SupplierId { get; set; }
        public virtual SupplierMasterVM SupplierMaster { get; set; }
    }
}
