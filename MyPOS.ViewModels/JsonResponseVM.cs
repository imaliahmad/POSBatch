using System;
using System.Collections.Generic;
using System.Text;

namespace MyPOS.ViewModels
{
    public class JsonResponseVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> ErrorList { get; set; }
        public object Data { get; set; } //single/ list of objects
    }
}
