using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Dao;
using Context.Database;
using HSCB.Common;
using HSCB.SingleTon;

namespace HSCB.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var model = CategorySingleTon.GetChildCategories(0);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            if (id < 0)
            {
                id = 0;
            }

            var model = new Category()
            {
                ParentID = id
            };

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var loginAcc = (UserLogin)Session[CommonConstants.USER_SESSION];
                if (loginAcc != null)
                {
                    category.MetaTitle = category.Name;
                    category.SeoTitle = category.Name;
                    category.Status = true;
                    category.ShowOnHome = true;
                    category.CreatedDate = DateTime.Now;
                    category.CreatedBy = loginAcc.UserName;
                    category.ModifiedDate = DateTime.Now;

                    new CategoryDao().Insert(category);

                    CategorySingleTon.UpdateData();
                }
            }

            return RedirectToAction("Details", "Category", new {id = category.ParentID});
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                RedirectToAction("Details", "Category", new {id = 0});
            }

            var model = CategorySingleTon.GetChildCategories(id);

            ViewBag.currentId = id;
            ViewBag.parentId = id == 0 ? 0 : CategorySingleTon.GetById(id).ParentID;

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var helper = new CategoryDao();
            var model = helper.GetById(id);

            if (model == null)
            {
                return RedirectToAction("Index", "Category");
            }

            var tempList = helper.GetAll();

            var listCategory = tempList.Where(p => p.ParentID == model.ParentID).ToList();

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
                if (category.ID == category.ParentID)
                {
                    ModelState.AddModelError("","Danh mục cha không hợp lệ");


                    var helper = new CategoryDao();

                    var tempList = helper.GetAll();

                    var listCategory = tempList.Where(p => p.ParentID == category.ParentID).ToList();

                    listCategory.Add(new Category()
                    {
                        ID = 0,
                        Name = "Không có"
                    });

                    ViewBag.Category = new SelectList(listCategory, "Id", "Name", 0);
                    return View(category);
                }

                var loginAcc = (UserLogin)Session[CommonConstants.USER_SESSION];
                if (loginAcc != null)
                {
                    
                    category.SeoTitle = category.Name;
                    category.ModifiedBy = loginAcc.UserName;
                    category.ModifiedDate = DateTime.Now;

                    new CategoryDao().Update(category);

                    CategorySingleTon.UpdateData();
                }

            }

            return RedirectToAction("Details", "Category", new { id = category.ParentID });
        }
        
    }
}