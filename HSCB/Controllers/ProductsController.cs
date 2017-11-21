using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HSCB.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                ViewBag.id = id;
            }

            return View();
        }
    }
}