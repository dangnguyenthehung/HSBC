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
    public class ActivityFieldController : Controller
    {
        // GET: ActivityField
        [MvcSiteMapNode(Title = "Lĩnh vực hoạt động", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstants.ActitityField.BaseNode)]
        public ActionResult Index()
        {
            return RedirectToAction("FarmSystem");
        }


        [MvcSiteMapNode(Title = "Sản xuất chăn nuôi và trồng trọt", ParentKey = SiteMapKeyConstants.ActitityField.BaseNode, Key = SiteMapKeyConstants.ActitityField.FarmSystem)]
        public ActionResult FarmSystem()
        {
            return View();
        }


        [MvcSiteMapNode(Title = "Xuất khẩu nông sản", ParentKey = SiteMapKeyConstants.ActitityField.BaseNode, Key = SiteMapKeyConstants.ActitityField.ImportExport)]
        public ActionResult ImportExport()
        {
            return View();
        }
    }
}