using MayTinhCaNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayTinhCaNhan.Controllers
{
    public class CheckListController : Controller
    {
        // GET: CheckList
        List<Mail> Mails = new List<Mail>
        {
            new Mail
            {
                To ="manhhung1@gmail.com",
                Subject = "Chu de 1",
                Status = "oki"
            },
            new Mail
            {
                To = "manhhung2@gmail.com",
                Subject = "Chur de 2",
                Status = "oki"
            }
        };
        public ActionResult Index()
        {
            ViewBag.Mails = new SelectList(Mails, "Status", "Subject", "To");
            return View(Mails);
        }
    }
}