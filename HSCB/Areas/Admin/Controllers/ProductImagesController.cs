using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Dao;
using Context.Database;
using HSCB.Common;
using HSCB.Constants;

namespace HSCB.Areas.Admin.Controllers
{
    public class ProductImagesController : AdminBaseController
    {
        /*
        // GET: Admin/Images
        public ActionResult Index(int page = 1, int pageSize = 15)
        {
            var model = new ImagesDao().GetProductImagesAll((int)Enums.Category.SanPham, page, pageSize);
            
            return View(model);
        }

        public ActionResult Create()
        {
            GetData();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images/hscb/uploads/"), fileName);
                file.SaveAs(path);

                model.Url = $"/Content/images/hscb/uploads/{fileName}";

                var contentDao = new ContentDao();
                var content = contentDao.GetMainContentOfCategory(model.IdContent); // => Id content here = IdCategory

                model.IdContent = content.Id;

                new ImagesDao().Insert(model);

                TempData[CommonConstants.Message] = MessageConstants.InsertSuccess;
                
                return RedirectToAction("Create", "ProductImages");
            }

            GetData();

            return View(model);
        }

        private void GetData()
        {
            var categoryDao = new CategoryDao();
            var listCategoryAll = categoryDao.GetAll();

            var listCategory = listCategoryAll.Where(p => p.ParentID == (int)Enums.Category.SanPham).ToList();

            ViewBag.Category = new SelectList(listCategory, "Id", "Name");
        }
        */
    }
}