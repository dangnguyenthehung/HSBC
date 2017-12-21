using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Context.Dao;
using Context.Utilities;
using HSCB.Constants;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace HSCB.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [MvcSiteMapNode(Title = "Tin tức - Sự kiện", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstants.News.BaseNode)]
        public ActionResult Index()
        {
            return RedirectToAction("Activity");
        }

        //get all
        [MvcSiteMapNode(Title = "Hoạt động HSCB", ParentKey = SiteMapKeyConstants.News.BaseNode, Key = SiteMapKeyConstants.News.Activity)]
        public ActionResult Activity()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int) Enums.Category.HoatDongHSCB);

            return View(model);
        }

        //get details
        [MvcSiteMapNode(Title = "Chi tiết", ParentKey = SiteMapKeyConstants.News.BaseNode, Key = SiteMapKeyConstants.News.Details, PreservedRouteParameters = "id")]
        [SiteMapTitle(ViewDataConstants.SiteMapTitle, Target = AttributeTarget.CurrentNode)]
        public ActionResult NewsDetails(int id)
        {

            var helper = new ContentDao();

            var model = helper.GetContentByIdContent(id);

            if (model != null)
            {
                ViewData[ViewDataConstants.SiteMapTitle] = model.Title.Truncate(50);
                return View(model);
            }

            var message = MessageConstants.NotFound;
            return RedirectToAction("Index", "Message", new {message});

        }

        [MvcSiteMapNode(Title = "Tin tức sản phẩm", ParentKey = SiteMapKeyConstants.News.BaseNode, Key = SiteMapKeyConstants.News.ProductNews)]
        public ActionResult ProductNews()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int)Enums.Category.TinTucSanPham);

            return View(model);
        }

        [MvcSiteMapNode(Title = "Thông cáo báo chí", ParentKey = SiteMapKeyConstants.News.BaseNode, Key = SiteMapKeyConstants.News.PressRelease)]
        public ActionResult PressRelease()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int)Enums.Category.ThongCaoBaoChi);

            return View(model);
        }
    }
}