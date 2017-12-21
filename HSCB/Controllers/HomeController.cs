using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context;
using Context.Dao;
using Context.Database;
using HSCB.Common;
using HSCB.Constants;
using HSCB.Models;
using MvcSiteMapProvider;

namespace HSCB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [MvcSiteMapNode(Title = "Trang chủ", Key = SiteMapKeyConstants.RootNode)]
        public ActionResult Index()
        {
            var helper = new ContentDao();
            

            ViewBag.companyActivity = new HomePageNewsDTO()
            {
                NewContent = helper.GetNewContent((int)Enums.Category.HoatDongHSCB),
                OldContents = helper.GetOldContents((int)Enums.Category.HoatDongHSCB)

            };

            ViewBag.productNews = new HomePageNewsDTO()
            {
                NewContent = helper.GetNewContent((int)Enums.Category.TinTucSanPham),
                OldContents = helper.GetOldContents((int)Enums.Category.TinTucSanPham)

            };


            return View();
        }
    }
}