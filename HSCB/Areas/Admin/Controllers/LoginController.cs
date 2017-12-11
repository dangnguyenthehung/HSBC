using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Dao;
using HSCB.Common;

namespace HSCB.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                model.PassWord = Utilities.Utilities.EncryptMd5(model.PassWord);

                var result = dao.Login(model.UserName, model.PassWord);

                if (result != null)
                {
                    var user = dao.GetById(model.UserName);

                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(Common.CommonConstants.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Contact");
                }
                
                ModelState.AddModelError("", "Đăng nhập thất bại");
            }

            return View(model);
            
        }

        public ActionResult Logout()
        {
            if (Session[CommonConstants.USER_SESSION] != null)
            {
                Session.Remove(CommonConstants.USER_SESSION);
            }

            return RedirectToAction("Index", "Login");
        }
    }
}