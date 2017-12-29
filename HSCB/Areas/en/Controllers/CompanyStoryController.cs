using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HSCB.Common;
using HSCB.Constants;
using MvcSiteMapProvider;

namespace HSCB.Areas.en.Controllers
{
    public class CompanyStoryController : Controller
    {
        // GET: CompanyStory
        [MvcSiteMapNode(Title = "Câu chuyện HSCB", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstants.CompanyStory.BaseNode)]
        public ActionResult Index()
        {
            return RedirectToAction("AboutUs");
        }

        [MvcSiteMapNode(Title = "Về chúng tôi", ParentKey = SiteMapKeyConstants.CompanyStory.BaseNode, Key = SiteMapKeyConstants.CompanyStory.AboutUs)]
        public ActionResult AboutUs()
        {
            return View();
        }

        [MvcSiteMapNode(Title = "Chiến lược phát triển", ParentKey = SiteMapKeyConstants.CompanyStory.BaseNode, Key = SiteMapKeyConstants.CompanyStory.DevelopmentPlan)]
        public ActionResult DevelopmentPlan()
        {
            return View();
        }
    }
}