using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context;
using Context.Dao;
using Context.Database;
using HSCB.Models;

namespace HSCB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var helper = new ContentDao();
            

            var companyActivity = new HomePageNewsDTO()
            {
                NewContent = helper.GetNewContent((int)Enums.Category.HoatDongHSCB),
                OldContents = helper.GetOldContents((int)Enums.Category.HoatDongHSCB)

            };

            var productNews = new HomePageNewsDTO()
            {
                NewContent = helper.GetNewContent((int)Enums.Category.TinTucSanPham),
                OldContents = helper.GetOldContents((int)Enums.Category.TinTucSanPham)

            };


            return View();
        }
    }
}