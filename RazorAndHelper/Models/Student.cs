using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RazorAndHelper.Models
{
    public class Student
    {
        [DisplayName("Ma sinh vien"), DataType(DataType.Text)]
        [Required(ErrorMessage ="Vui lòng nhập mã sinh viên")]
        [MinLength(5, ErrorMessage ="Ma sinh vien phai nhiều hơn 5 kí tự")]
        [Range(1,100,ErrorMessage ="Ma sinh vien chay tu 1 đến 100")]
        public string ID { get; set; }
        [DisplayName("Mật khẩu"), DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Họ và tên")]
        public string Fullname { get; set; }
        [DisplayName("Giới tính")]
        public bool Gender { get; set; }
        [DisplayName("Ngày sinh"), DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
        [DisplayName("Ghi chú"), DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}