using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayTinhCaNhan.Models
{
    public class MailInfo
    {
        public string From { get; set; }
        public string To { set; get; }
        public string Subject { set; get; }
        public string Body { set; get; }
    }
}