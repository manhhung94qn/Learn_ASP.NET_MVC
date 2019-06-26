using MayTinhCaNhan.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MayTinhCaNhan.Controllers
{
    public class ShowInforStudentController : Controller
    {
        // GET: ShowInforStudent
        SinhVienInfor Student = new SinhVienInfor
        {
            Id = "1",
            Name = "Manh Hung",
            Marks = 10,
        };
        SinhVienInfor Student2 = new SinhVienInfor
        {
            Id = "2",
            Name = "Manh Kha",
            Marks = 10,
        };
        MailInfo Mail = new MailInfo
        {
            From = "Manhhung94qn@gmail.com",
            To = "Rong",
            Subject = "Tieu de",
            Body = "Noi dung cua tin nhan"
        };
        public ActionResult Index()
        {
            List<SinhVienInfor> Danhsach = new List<SinhVienInfor>();
            Danhsach.Add(Student);
            Danhsach.Add(Student2);
            return View(Danhsach);
        }
    }
}