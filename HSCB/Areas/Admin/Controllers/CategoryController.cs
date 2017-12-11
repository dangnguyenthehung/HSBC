using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Dao;
using Context.Database;
using HSCB.SingleTon;

namespace HSCB.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var helper = new CategoryDao();
            var model = helper.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var helper = new CategoryDao();
            var tempList = helper.GetAll();

            var listCategory = tempList.Where(p => p.ParentID == 0).ToList();

            listCategory.Add(new Category()
            {
                ID = 0,
                Name = "Không có"
            });

            ViewBag.Category = new SelectList(listCategory, "Id", "Name", 0);

            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Status = true;
                category.CreatedDate = DateTime.Now;
                category.ModifiedDate = DateTime.Now;

                new CategoryDao().Insert(category);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var helper = new CategoryDao();
            var model = helper.GetById(id);

            if (model == null)
            {
                return RedirectToAction("Index","Category");
            }

            var tempList = helper.GetAll();

            var listCategory = tempList.Where(p => p.ParentID == 0).ToList();

            listCategory.Add(new Category()
            {
                ID = 0,
                Name = "Không có"
            });

            ViewBag.Category = new SelectList(listCategory, "Id", "Name", 0);

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                category.ModifiedDate = DateTime.Now;

                new CategoryDao().Update(category);
            }

            return RedirectToAction("Index");
        }
    }
}