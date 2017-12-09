using Context.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HSCB.Constants;
using HSCB.Models;

namespace HSCB.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            if (id > 0)
            {
                var helper = new ContentDao();
                
                var model = new ProductViewModel();
                    
                model.Content = helper.GetMainContentOfCategory(id);

                var imageHelper = new ImagesDao();
                model.ImagesList = imageHelper.GetImages(model.Content.Id); 

                return View(model);
            }

            var message = MessageConstants.NotFound;
            return RedirectToAction("Index", "Message", new RouteValueDictionary(message));
        }
    }
}