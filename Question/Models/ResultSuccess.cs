using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class ResultSuccess<T>
    {
        public PageResult<T> results { get; set; }
    }
}