using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPOS.BOL
{
    public class ImageMaster
    {
        [Key]
        public long ImageMasterId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }



        //Navigation
        public virtual SupplierMaster SupplierMaster { get; set; }
    }
}
