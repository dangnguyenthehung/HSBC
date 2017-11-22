using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HSCB.Models;

namespace HSCB.Controllers
{
    public class ContactController : Controller
    {
        private Context.Database.hscbEntities db = new Context.Database.hscbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var contact = new Contact();
            return View("Index", contact);
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var data = new Context.Database.Contact()
                {
                    Email = contact.Email,
                    Name = contact.Name,
                    Phone = contact.Phone
                };

                db.Contacts.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }


            return View(contact);
        }
    }
}