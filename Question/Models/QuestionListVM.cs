using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class QuestionListVM
    {
        //ID định danh trên app Người Dân
        public long id { get; set; }

        public int? web_id { get; set; }

        //Trạng thái
        //0: chờ trả lời
        //1: đã trả lời
        //2: ẩn(xóa)
        public int status { get; set; }

        //ID đơn vị hỏi
        public int? organization_id { get; set; }

        //Họ và tên người gửi câu hỏi
        public string full_name { get; set; }

        //Địa chỉ
        public string address { get; set; }

        //Số CMTND (Hộ chiếu)
        public string card_id { get; set; }

        //Số điện thoại
        public string phone { get; set; }

        //Địa chỉ Email
        public string email { get; set; }

        //Ngày hỏi
        public long created_at { get; set; }

        //Tiêu đề(millisecond)

        public string title { get; set; }

        //Nội dung câu hỏi
        public string content { get; set; }

        public List<AnswerQ> answers { get; set; }

        //TG cập nhật cuối (millisecond)
        public long last_update_time { get; set; }
    }
}