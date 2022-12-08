using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPOS.ViewModels
{
    public class SupplierMasterVM : BaseEntityVM
    {
        public int SupplierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public long ImageMasterId { get; set; } //fk


        //Navigation
        public virtual SupplierMasterVM SupplierMaster { get; set; }
        public virtual List<ProductMasterVM> ProductMaster { get; set; }
    }
}
