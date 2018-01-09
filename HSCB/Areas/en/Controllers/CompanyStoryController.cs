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
        [MvcSiteMapNode(Title = "Câu chuyện HSCB", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstantsEnglish.CompanyStory.BaseNode)]
        public ActionResult Index()
        {
            return RedirectToAction("AboutUs");
        }

        [MvcSiteMapNode(Title = "Về chúng tôi", ParentKey = SiteMapKeyConstantsEnglish.CompanyStory.BaseNode, Key = SiteMapKeyConstantsEnglish.CompanyStory.AboutUs)]
        public ActionResult AboutUs()
        {
            return View();
        }

        [MvcSiteMapNode(Title = "Chiến lược phát triển", ParentKey = SiteMapKeyConstantsEnglish.CompanyStory.BaseNode, Key = SiteMapKeyConstantsEnglish.CompanyStory.DevelopmentPlan)]
        public ActionResult DevelopmentPlan()
        {
            return View();
        }
    }
}