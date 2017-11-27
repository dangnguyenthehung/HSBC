using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Database;
using HSCB.Utilities;
using Contact = HSCB.Models.Contact;

namespace HSCB.Helper
{
    public class ContactHelper
    {
        public bool Insert(Contact contact)
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var data = contact.Cast<Context.Database.Contact>();

                    context.Contacts.Add(data);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    //
                    return false;
                }
            }
        }

        public List<Contact> GetAll()
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var result = context.Contacts.ToList();

                    var response = result.Cast<Contact>().ToList();

                    response = response.OrderByDescending(c => c.ID).ToList();
                    
                    return response;
                }
                catch (Exception ex)
                {
                    //
                    return null;
                }
            }
        }
    }
}