using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Context.Dao;
using Context.Utilities;
using HSCB.Constants;
using HSCB.Models;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace HSCB.Areas.en.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [MvcSiteMapNode(Title = "Tin tức - Sự kiện", ParentKey = SiteMapKeyConstants.RootNode, Key = SiteMapKeyConstantsEnglish.News.BaseNode)]
        public ActionResult Index()
        {
            return RedirectToAction("Activity");
        }

        //get all
        [MvcSiteMapNode(Title = "Hoạt động HSCB", ParentKey = SiteMapKeyConstantsEnglish.News.BaseNode, Key = SiteMapKeyConstantsEnglish.News.Activity)]
        public ActionResult Activity()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int) Enums.Category.HoatDongHSCB);

            return View(model);
        }

        //get details
        [MvcSiteMapNode(Title = "Chi tiết", ParentKey = SiteMapKeyConstantsEnglish.News.BaseNode, Key = SiteMapKeyConstantsEnglish.News.Details, PreservedRouteParameters = "id")]
        [SiteMapTitle(ViewDataConstants.SiteMapTitle, Target = AttributeTarget.CurrentNode)]
        public ActionResult NewsDetails(int id)
        {
            var helper = new ContentDao();

            var model = helper.GetContentByIdContent(id);

            if (model != null)
            {
                ViewData[ViewDataConstants.SiteMapTitle] = model.Title.Truncate(50);

                GetSimilarPost(id);

                return View(model);
            }

            var message = MessageConstants.NotFound;
            return RedirectToAction("Index", "Message", new {message});

        }

        [MvcSiteMapNode(Title = "Tin tức sản phẩm", ParentKey = SiteMapKeyConstantsEnglish.News.BaseNode, Key = SiteMapKeyConstantsEnglish.News.ProductNews)]
        public ActionResult ProductNews()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int)Enums.Category.TinTucSanPham);

            return View(model);
        }

        [MvcSiteMapNode(Title = "Thông cáo báo chí", ParentKey = SiteMapKeyConstantsEnglish.News.BaseNode, Key = SiteMapKeyConstantsEnglish.News.PressRelease)]
        public ActionResult PressRelease()
        {
            var helper = new ContentDao();

            var model = helper.GetByCategory((int)Enums.Category.ThongCaoBaoChi);

            return View(model);
        }


        //Similar post
        private void GetSimilarPost(int id)
        {
            var response = new List<SimilarPostDTO>();

            var helper = new ContentDao();
            var content = helper.GetContentByIdContent(id);

            var number = Convert.ToInt32(WebConfigurationManager.AppSettings["similarPost"]);

            if (content.CategoryID != null)
            {
                var listAll = helper.GetByCategory(content.CategoryID.Value).OrderBy(c => c.CreatedDate).ToList();
                var index = listAll.IndexOf(listAll.Find(c => c.Id == id));

                if (index < number)
                {
                    for (var i = 0; i < index; i++)
                    {
                        var item = listAll[i];
                        response.Add(new SimilarPostDTO(item.Id, item.Title));
                    }
                }
                else
                {
                    for (var i = (index - number); i < index; i++)
                    {
                        var item = listAll[i];
                        response.Add(new SimilarPostDTO(item.Id, item.Title));
                    }

                }

                if (index >= (listAll.Count - number))
                {
                    for (var i = (index + 1); i < listAll.Count; i++)
                    {
                        var item = listAll[i];
                        response.Add(new SimilarPostDTO(item.Id, item.Title));
                    }
                }
                else
                {
                    for (var i = (index + 1); i <= (number + index); i++)
                    {
                        var item = listAll[i];
                        response.Add(new SimilarPostDTO(item.Id, item.Title));
                    }
                }
            }

            ViewBag.similarPost = response;
        }

    }
}