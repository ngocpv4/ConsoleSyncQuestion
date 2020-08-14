using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class OrganizationRequestVM
    {
        //ID định danh
        public int id { get; set; }

        //Tên đơn vị
        public string name { get; set; }

        //1: active
        //0: inactive
        public int status { get; set; }
    }
}