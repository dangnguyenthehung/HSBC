using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSCB.Areas.en.Controllers
{
    public class ChangeLanguageController : Controller
    {
        // GET: ChangeLanguage
        public ActionResult Index(int language)
        {
            switch (language)
            {
                case 0:
                    return RedirectToAction("Index", "Home", new { area = "" });
                case 1:
                    return RedirectToAction("Index", "Home", new { area = "en" });
                default: break;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}