using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Database;
using Context.Dao;
using HSCB.Common;
using HSCB.SingleTon;
using HSCB.Utilities;

namespace HSCB.Areas.Admin.Controllers
{
    public class ContentController : AdminBaseController
    {

        // GET: Admin/Content
        public ActionResult Index()
        {
            var model = new ContentDao().GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categoryDao = new CategoryDao();
            var listCategory = categoryDao.GetAll();

            ViewBag.Category = new SelectList(listCategory, "Id", "Name");

            return View();
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
                return RedirectToAction("Index", "Category");
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
    }
}