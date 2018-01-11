using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSCB.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        // GET: Admin/Message
        public ActionResult Index(string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}