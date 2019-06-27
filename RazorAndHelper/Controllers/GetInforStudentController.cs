using RazorAndHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorAndHelper.Controllers
{
    public class GetInforStudentController : Controller
    {
        // GET: GetInforStudentS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kiemtra(Student st)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bạn đã đăng kí thành công");
            }
            return View();
        }
    }
}