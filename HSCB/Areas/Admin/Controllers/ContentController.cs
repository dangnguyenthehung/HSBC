﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Database;
using Context.Dao;
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
            var listCategory = CategorySingleTon.GetAllCategories();

            ViewBag.Category = new SelectList(listCategory, "Id", "Name");

            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                content.Status = true;
                content.CreatedDate = DateTime.Now;
                content.ModifiedDate = DateTime.Now;
                
                new ContentDao().Insert(content);
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

            var listCategory = CategorySingleTon.GetAllCategories();
            
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
                content.ModifiedDate = DateTime.Now;

                new ContentDao().Update(content);
            }

            return RedirectToAction("Index");
        }
    }
}