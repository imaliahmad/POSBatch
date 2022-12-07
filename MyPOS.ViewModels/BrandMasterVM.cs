using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPOS.ViewModels
{
    public class BrandMasterVM:BaseEntityVM
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



        //Navigation
        public virtual List<ProductMasterVM> ProductMaster { get; set; }
    }
}
