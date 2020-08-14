using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class AnswerQ
    {
        //ID định danh trên web Thành phố Hải Dương
        public int id { get; set; }

        //ID đơn vị trả lời
        public int? organization_id { get; set; }

        //Nội dung câu trả lời
        public string answer { get; set; }

        //Thời gian trả lời(Thời gian đổi quy đổi ra milisecond)
        public long created_at { get; set; }
    }
}