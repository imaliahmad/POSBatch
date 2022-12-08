using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPOS.ViewModels
{
    public class ImageMasterVM: BaseEntityVM
    {
        [Key]
        public long ImageMasterId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }



        //Navigation
        public virtual SupplierMasterVM SupplierMaster { get; set; }
    }
}
