using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class PagePost<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<T> data { get; set; }
    }

    public class ResultPostSuccess<T>
    {
        public PagePost<T> results { get; set; }
    }
}