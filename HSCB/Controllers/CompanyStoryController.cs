using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSCB.Controllers
{
    public class CompanyStoryController : Controller
    {
        // GET: CompanyStory
        public ActionResult Index()
        {
            return View("AboutUs");
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult DevelopmentPlan()
        {
            return View();
        }
    }
}