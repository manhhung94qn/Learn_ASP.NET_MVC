using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var SesstionOnUserLogin = Session[CommonConstants.USER_SESSION];
            if(SesstionOnUserLogin == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new {Controller = "Login", Action = "Login", Area = "Admin"}
                        )
                    );
            }
            base.OnActionExecuted(filterContext);
        }
    }
}