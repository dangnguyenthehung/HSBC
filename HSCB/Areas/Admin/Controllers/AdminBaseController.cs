using HSCB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HSCB.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Session[CommonConstants.USER_SESSION] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}