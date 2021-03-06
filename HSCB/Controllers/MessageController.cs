﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HSCB.Common;
using HSCB.Constants;
using MvcSiteMapProvider;

namespace HSCB.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        [MvcSiteMapNode(Title = "Thông báo", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstants.Message.BaseNode, PreservedRouteParameters = "message")]
        public ActionResult Index(string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}