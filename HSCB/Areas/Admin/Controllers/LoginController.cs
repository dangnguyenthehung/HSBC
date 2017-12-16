using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Context.Dao;
using Context.Utilities;
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
                model.PassWord = Utilities.EncryptMd5(model.PassWord);

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

        public ActionResult ChangePassword()
        {
            if (Session[CommonConstants.USER_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldPassword, string newPassword, string newPasswordRetype)
        {
            if (newPassword != newPasswordRetype)
            {
                ModelState.AddModelError("","Mật khẩu nhập lại không khớp");

                return View();
            }
            
            if (Session[CommonConstants.USER_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var user = (UserLogin) Session[CommonConstants.USER_SESSION];

            oldPassword = Utilities.EncryptMd5(oldPassword);
            newPassword = Utilities.EncryptMd5(newPassword);

            var result = new UserDao().ChangePassword(user.UserID, oldPassword, newPassword);

            if (result)
            {
                return RedirectToAction("Logout");
            }
            
            return View();
        }
    }
}