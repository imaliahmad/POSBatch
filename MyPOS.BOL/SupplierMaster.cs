using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyPOS.BOL
{
    public class SupplierMaster:BaseEntity
    {
        [Key]
        public int SupplierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }


        [ForeignKey("ImageMaster")]
        public long ImageMasterId { get; set; }
        public virtual ImageMaster ImageMaster { get; set; }


        //Navigation
        public virtual List<ProductMaster> ProductMaster { get; set; }
    }
}
