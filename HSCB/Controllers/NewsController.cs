using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Dao;
using HSCB.Constants;

namespace HSCB.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        //get all
        public ActionResult Activity()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int) Enums.Category.HoatDongHSCB);

            return View(model);
        }

        //get details
        public ActionResult ActivityDetails(int id)
        {
            return View();
        }

        public ActionResult ProductNews()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int)Enums.Category.TinTucSanPham);

            return View(model);
        }

        public ActionResult ProductNewsDetails(int id)
        {
            return View();
        }

        public ActionResult PressRelease()
        {
            return View();
        }
    }
}