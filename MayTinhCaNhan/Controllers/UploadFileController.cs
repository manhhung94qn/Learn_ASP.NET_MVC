using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayTinhCaNhan.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ViewResult Index()
        {
            ViewBag.FileName = "a";
            ViewBag.FileType = "a";
            ViewBag.FileSize = "a";
            return View();
            var f = Request.Files["document"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/UploadFiles/" + f.FileName);
                f.SaveAs(path);
                ViewBag.FileName = f.FileName;
                ViewBag.FileType = f.ContentType;
                ViewBag.FileSize = f.ContentLength;
            }
        }
        public ViewResult Upload()
        {
            var f = Request.Files["document"];
            if(f!=null && f.ContentLength > 0)
            {
                ViewBag.FileName = f.FileName;
                ViewBag.FileType = f.ContentType;
                ViewBag.FileSize = f.ContentLength;
            }
            return View();
        }
    }
}