using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.BOL
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
