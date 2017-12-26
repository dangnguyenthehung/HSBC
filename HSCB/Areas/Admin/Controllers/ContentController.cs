using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Database;
using Context.Dao;
using HSCB.Common;
using HSCB.SingleTon;
using Context.Utilities;

namespace HSCB.Areas.Admin.Controllers
{
    public class ContentController : AdminBaseController
    {

        // GET: Admin/Content
        public ActionResult Index()
        {
           return RedirectToAction("Details", "Content", new { id = 0 });
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            //var categoryDao = new CategoryDao();

            //var listCategory = categoryDao.GetAll();

            //ViewBag.Category = new SelectList(listCategory, "Id", "Name");

            var model = new Content()
            {
                CategoryID = id
            };

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            { var loginAcc = (UserLogin)Session[CommonConstants.USER_SESSION];
                if (loginAcc != null)
                {
                    content.Status = true;
                    content.CreatedBy = loginAcc.UserName;
                    content.CreatedDate = DateTime.Now;
                    content.ModifiedDate = DateTime.Now;

                    new ContentDao().Insert(content);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ContentDao().GetContentByIdContentAll(id);

            if (model == null)
            {
                return RedirectToAction("Create", "Content");
            }

            var categoryDao = new CategoryDao();
            var listCategory = categoryDao.GetAll();

            ViewBag.Category = new SelectList(listCategory, "Id","Name", model.CategoryID);

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                var loginAcc = (UserLogin)Session[CommonConstants.USER_SESSION];
                if (loginAcc != null)
                {

                    content.ModifiedDate = DateTime.Now;
                    content.ModifiedBy = loginAcc.UserName;

                    new ContentDao().Update(content);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                RedirectToAction("Details", "Content", new { id = 0 });
            }

            var model = CategorySingleTon.GetChildCategories(id);

            if (!model.Any())
            {
                return RedirectToAction("ListContent", "Content", new {id});
            }

            ViewBag.currentId = id;
            ViewBag.parentId = id == 0 ? 0 : CategorySingleTon.GetById(id).ParentID;

            return View(model);
        }

        [HttpGet]
        public ActionResult ListContent(int id)
        {
            if (id < 0)
            {
                RedirectToAction("Details", "Content", new { id });
            }

            var model = new ContentDao().GetByCategory(id);

            ViewBag.currentId = id;
            ViewBag.parentId = id == 0 ? 0 : CategorySingleTon.GetById(id).ParentID;

            return View(model);
        }
    }
}