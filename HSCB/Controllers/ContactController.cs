﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HSCB.Constants;
using HSCB.Helper;
using HSCB.Models;

namespace HSCB.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var contact = new Contact();
            return View(contact);
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var helper = new ContactHelper();
                var result = helper.Insert(contact);

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }

                var message = MessageConstants.ContactSubmitFail;
                return RedirectToAction("Index", "Message", new RouteValueDictionary(message));
            }


            return View(contact);
        }
    }
}