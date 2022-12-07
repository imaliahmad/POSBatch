using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.ViewModels
{
    public class CategoryMasterVM : BaseEntityVM
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //Navigation
        public virtual List<ProductMasterVM> ProductMaster { get; set; }
    }
}
