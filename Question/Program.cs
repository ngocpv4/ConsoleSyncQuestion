using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Question.Models;
using Newtonsoft.Json;

namespace Question
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Lấy danh sách câu hỏi tạo mới trên App Người Dân
            Console.WriteLine("Lấy danh sách câu hỏi tạo mới trên App Người Dân");
            GetListQuestion(5, 0);
            Console.WriteLine("\n");

            //Thêm, cập nhật danh sách đơn vị trả lời lên app
            Console.WriteLine("Thêm, cập nhật danh sách đơn vị trả lời lên app");
            var organizations = new List<OrganizationRequestVM>()
            {
                new OrganizationRequestVM()
                {
                    id = 101,
                    name = "Test 01",
                    status = 1
                },
                new OrganizationRequestVM()
                {
                    id = 16,
                    name = "Test 02",
                    status = 1
                },
            };
            PostOrganization(organizations);
            Console.WriteLine("\n");

            //Thêm mới, cập nhật danh sách câu hỏi, trả lời lên app
            Console.WriteLine("Thêm mới, cập nhật danh sách câu hỏi, trả lời lên app");
            var questions = new List<QuestionCreateRequestVM>()
            {
                new QuestionCreateRequestVM()
                {
                    id = 12,
                    type = 0,
                    app_id = 2,
                    status = 2,
                    organization_id = 12,
                    full_name = "Nguyen Van A",
                    address = "",
                    card_id = "151869940",
                    phone = "0389488932",
                    email = "sonnhs@gmail.com",
                    title = "Cấp lí lịch tư pháp số 1",
                    content = "Tôi đang có nhu cầu làm lý lịch tư pháp số 1 để phục vụ cho công việc, vậy xin hỏi làm lý lịch tư pháp số 1 cần các giầy tờ gì và thời gian cấp trong bao lâu?",
                    answers = new List<AnswerQ>()
                    {
                        new AnswerQ()
                        {
                            id = 73851,
                            organization_id = 12,
                            answer = "Chào bạn, Hiện tại các thủ tục hành chính thực hiện tại Trung tâm Phục vụ Hành chính công (Số 1 Tôn Đức Thắng, TPHD). Bạn tham khảo các bước thực hiện tại địa chỉ: http://thutuchanhchinh.haiduong.gov.vn/TTHCView.aspx?thutucID=3312 hay liên hệ trực tiếp trung tâm để được hướng dẫn nhé",
                            created_at = 1596531035878
                        }
                    },
                    created_at = 1596531035878,
                    last_update_time = 1596531035878
                }
            };
            PostQuestion(questions);
            Console.ReadLine();
        }

        /// <summary>
        /// Lấy danh sách câu hỏi tạo mới trên App Người Dân
        /// </summary>
        /// <param name="topnumber">số lượng bản ghi cần lấy</param>
        /// <param name="lastupdate">Lấy số lượng “topnumber” các câu hỏi có thời gian tạo hơn lastupdate,  => mỗi lần gọi api xong phía cổng cần lưu lại thời gian tạo của câu hỏi mới nhất, chưa từng lưu cần truyền 0</param>
        public static void GetListQuestion(int topnumber = 5, long lastupdate = 0)
        {
            WebRequest request = WebRequest.Create($"http://haiduong.tetvietaic.com/api/service/questions?last_update={lastupdate}&top_number={topnumber}");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");

            try
            {
                // Get the response.
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Convert data
                        var results = JsonConvert.DeserializeObject<ResultSuccess<QuestionListVM>>(responseFromServer);
                        Console.WriteLine(JsonConvert.SerializeObject(results));
                    }
                }
            }
            catch (WebException exception)
            {
                HttpWebResponse errorResponse = (HttpWebResponse)exception.Response;
                using (Stream errorDataStream = errorResponse.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader errorResponseFromServer = new StreamReader(errorDataStream);
                    // Read the content.
                    string erorResult = errorResponseFromServer.ReadToEnd();
                    // Convert data
                    var errors = JsonConvert.DeserializeObject<ResultError>(erorResult);
                    Console.WriteLine(JsonConvert.SerializeObject(errors));
                }
            }
        }

        /// <summary>
        /// Thêm, cập nhật danh sách đơn vị trả lời lên app
        /// </summary>
        /// <param name="organizations">Danh sách đơn vị</param>
        /// <returns></returns>
        public static void PostOrganization(List<OrganizationRequestVM> organizations)
        {
            WebRequest request = WebRequest.Create($"http://haiduong.tetvietaic.com/api/service/question/organization/create");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(organizations);
                streamWriter.Write(json);
            }

            try
            {
                // Get the response.
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();

                        var results = JsonConvert.DeserializeObject<ResultPostSuccess<OrganizationResponseVM>>(responseFromServer);
                        Console.WriteLine(JsonConvert.SerializeObject(results));
                    }
                }
            }
            catch (WebException exception)
            {
                HttpWebResponse errorResponse = (HttpWebResponse)exception.Response;
                using (Stream errorDataStream = errorResponse.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader errorResponseFromServer = new StreamReader(errorDataStream);
                    // Read the content.
                    string erorResult = errorResponseFromServer.ReadToEnd();
                    // Convert data
                    var errors = JsonConvert.DeserializeObject<ResultError>(erorResult);
                    Console.WriteLine(JsonConvert.SerializeObject(errors));
                }
            }
        }

        /// <summary>
        /// Thêm mới, cập nhật danh sách câu hỏi, trả lời lên app
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public static void PostQuestion(List<QuestionCreateRequestVM> questions)
        {
            WebRequest request = WebRequest.Create($"http://haiduong.tetvietaic.com/api/service/question/create");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(questions);
                streamWriter.Write(json);
            }

            try
            {
                // Get the response.
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();

                        var results = JsonConvert.DeserializeObject<ResultPostSuccess<QuestionCreateResponseVM>>(responseFromServer);
                        Console.WriteLine(JsonConvert.SerializeObject(results));
                    }
                }
            }
            catch (WebException exception)
            {
                HttpWebResponse errorResponse = (HttpWebResponse)exception.Response;
                using (Stream errorDataStream = errorResponse.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader errorResponseFromServer = new StreamReader(errorDataStream);
                    // Read the content.
                    string erorResult = errorResponseFromServer.ReadToEnd();
                    // Convert data
                    var errors = JsonConvert.DeserializeObject<ResultError>(erorResult);
                    Console.WriteLine(JsonConvert.SerializeObject(errors));
                }
            }
        }
    }
}