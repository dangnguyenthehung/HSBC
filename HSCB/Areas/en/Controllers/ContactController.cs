using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HSCB.Common;
using HSCB.Constants;
using HSCB.Helper;
using HSCB.Models;
using MvcSiteMapProvider;

namespace HSCB.Areas.en.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        [MvcSiteMapNode(Title = "Liên hệ", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstants.Contact.BaseNode)]
        public ActionResult Index()
        {
            var contact = new Contact();
            return View(contact);
        }

        [HttpPost]
        [MvcSiteMapNode(Title = "Liên hệ", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstants.Contact.IndexPost)]
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
                return RedirectToAction("Index", "Message", new {message});
            }


            return View(contact);
        }

        [HttpPost]
        public ActionResult ReceiveNews(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var contact = new Contact()
                {
                    Email = email,
                    Name = email,
                    Phone = "",
                    Status = "Nhận thông báo"
                };

                var helper = new ContactHelper();
                var result = helper.Insert(contact);

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }

                var message = MessageConstants.ContactSubmitFail;
                return RedirectToAction("Index", "Message", new { message });
            }

            return RedirectToAction("Index", "Home");

        }
    }
}