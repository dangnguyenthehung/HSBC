using Context.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HSCB.Common;
using HSCB.Constants;
using HSCB.Models;
using HSCB.SingleTon;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace HSCB.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [MvcSiteMapNode(Title = "Sản phẩm", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstants.Product.BaseNode)]
        public ActionResult Index()
        {
            ViewBag.listGroup = CategorySingleTon.GetChildCategories(((int) Enums.Category.SanPham));

            return View();
        }

        [MvcSiteMapNode(Title = "Chi tiết", ParentKey = SiteMapKeyConstants.Product.BaseNode, Key = SiteMapKeyConstants.Product.Group, PreservedRouteParameters = "id")]
        [SiteMapTitle(ViewDataConstants.SiteMapTitle, Target = AttributeTarget.CurrentNode)]
        public ActionResult Group(int id)
        {
            if (id > 0)
            {
                var list = CategorySingleTon.GetChildCategories(id);

                return View(list);
            }

            var message = MessageConstants.NotFound;
            return RedirectToAction("Index", "Message", new { message });
        }

        [MvcSiteMapNode(Title = "Chi tiết", ParentKey = SiteMapKeyConstants.Product.BaseNode, Key = SiteMapKeyConstants.Product.Details, PreservedRouteParameters = "id")]
        [SiteMapTitle(ViewDataConstants.SiteMapTitle, Target = AttributeTarget.CurrentNode)]
        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                var helper = new ContentDao();
                
                var model = new ProductViewModel();
                    
                model.Content = helper.GetMainContentOfCategory(id);

                if (model.Content != null)
                {
                    var imageHelper = new ImagesDao();
                    model.ImagesList = imageHelper.GetImages(model.Content.Id);

                    ViewData[ViewDataConstants.SiteMapTitle] = model.Content.Title;

                    return View(model);
                }
            }

            var message = MessageConstants.NotFound;
            return RedirectToAction("Index", "Message", new {message});
        }
    }
}