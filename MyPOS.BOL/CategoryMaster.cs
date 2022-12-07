using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPOS.BOL
{
    public  class CategoryMaster: BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //Navigation
        public virtual  List<ProductMaster> ProductMaster { get; set; }

    }
}
