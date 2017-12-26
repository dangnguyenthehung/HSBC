using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Database;

namespace Context.Dao
{
    public class CategoryDao
    {
        public Category GetById(int id)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Categories.SingleOrDefault(c => c.ID == id);

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public List<Category> GetAll()
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Categories.ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public bool Insert(Category category)
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var data = category;
                    context.Categories.Add(data);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Update(Category category)
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var data = context.Categories.Find(category.ID);

                    if (data != null)
                    {
                        context.Entry(data).CurrentValues.SetValues(category);
                        context.SaveChanges();
                    }


                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var category = context.Categories.Find(id);
                    if (category != null)
                    {
                        context.Categories.Remove(category);
                        context.SaveChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
