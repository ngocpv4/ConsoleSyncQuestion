using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<object> data { get; set; }
    }
}