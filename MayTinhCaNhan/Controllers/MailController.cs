using MayTinhCaNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MayTinhCaNhan.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            

            return View();
        }
        public ActionResult SendMail(MailInfo mailContent)
        {
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("manhhung94qn@gmail.com", "hung764119g"),
                EnableSsl = true
            };
            if (1 != 2)
            {

                var mess = new MailMessage();
                mess.To.Add(new MailAddress(mailContent.To));
                mess.From = new MailAddress(mailContent.From);
                mess.ReplyToList.Add(mailContent.From);
                mess.Subject = mailContent.Subject;
                mess.Body = mailContent.Body;
                mail.Send(mess);
            }
                return View("SendMail");
        }
        //public ActionResult SendMail(MailInfo mailContent)
        //{
        //}

    }
}