using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class QuestionCreateResponseVM
    {
        public long web_id { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public int organization_id { get; set; }
        public string full_name { get; set; }
        public string address { get; set; }
        public string card_id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}