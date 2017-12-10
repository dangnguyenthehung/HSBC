using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSCB.Controllers
{
    public class ActitityFieldController : Controller
    {
        // GET: ActitityField
        public ActionResult Index()
        {
            return View("FarmSystem");
        }

        public ActionResult FarmSystem()
        {
            return View();
        }

        public ActionResult ImportExport()
        {
            return View();
        }
    }
}