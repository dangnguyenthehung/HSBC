﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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

            var helper = new ContentDao();

            var model = helper.GetContentByIdContent(id);

            if (model != null)
            {
                return View(model);
            }

            var message = MessageConstants.NotFound;
            return RedirectToAction("Index", "Message", new RouteValueDictionary(message));

        }

        public ActionResult ProductNews()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int)Enums.Category.TinTucSanPham);

            return View(model);
        }

        public ActionResult ProductNewsDetails(int id)
        {
            var helper = new ContentDao();

            var model = helper.GetContentByIdContent(id);

            if (model != null)
            {
                return View(model);
            }

            var message = MessageConstants.NotFound;
            return RedirectToAction("Index", "Message", new RouteValueDictionary(message));
        }

        public ActionResult PressRelease()
        {
            return View();
        }
    }
}