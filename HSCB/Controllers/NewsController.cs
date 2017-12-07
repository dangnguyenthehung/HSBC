using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSCB.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Activity(int id)
        {
            return View();
        }

        public ActionResult ProductNews(int id)
        {
            return View();
        }

        public ActionResult PressRelease()
        {
            return View();
        }
    }
}