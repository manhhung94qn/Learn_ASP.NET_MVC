using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace MayTinhCaNhan.Controllers
{
    public class SinhVienInforController : Controller
    {
        // GET: SinhVienInfor
        public ActionResult Index()
        {
            ViewBag.id = "100";
            return View();
        }
        public ActionResult Save(string Id, string Name, string Mark)
        {
            string[] lines = { Id, Name, Mark };
            string path = @"C:\Test\manhhung94qn.txt";
            System.IO.File.WriteAllLines(path, lines);
            return View("Index");
        }
        public ActionResult Open()
        {
            string path = @"C:\Test\manhhung94qn.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            ViewBag.id = lines[0];
            ViewBag.name = lines[1];
            ViewBag.mark = lines[2];
            return View("Index");
        }
    }
}