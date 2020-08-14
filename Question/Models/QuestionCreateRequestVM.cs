using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Models
{
    public class QuestionCreateRequestVM
    {
        //ID định danh trên web Thành phố Hải Dương
        public int id { get; set; }

        //0: Câu hỏi tạo trên web  thông tin
        //1: Tạo trên app người dân
        public int type { get; set; }

        //ID định danh trên app Người Dân (chưa có truyền null)
        public int app_id { get; set; }

        //0: chờ trả lời
        //1: đã trả lời
        //2: ẩn(xóa)
        public int status { get; set; }

        //ID đơn vị trả lời câu hỏi
        public int organization_id { get; set; }

        //Họ và tên người gửi câu hỏi
        public string full_name { get; set; }

        //Địa chỉ người gửi
        public string address { get; set; }

        //Số CMTND/CCCD (Hộ chiếu)
        public string card_id { get; set; }

        //Số điện thoại
        public string phone { get; set; }

        //Địa chỉ Email
        public string email { get; set; }

        //Tiêu đề câu hỏi
        public string title { get; set; }

        //Nội dung câu hỏi
        public string content { get; set; }

        //mảng các câu trả lời từ các đơn vị, ko có để trống(xem bảng dưới)
        public List<AnswerQ> answers { get; set; }

        //Ngày hỏi(Thời gian đổi quy đổi ra milisecond)
        public long created_at { get; set; }

        //TG cập nhật cuối (Thời gian đổi quy đổi ra milisecond)
        public long last_update_time { get; set; }
    }
}