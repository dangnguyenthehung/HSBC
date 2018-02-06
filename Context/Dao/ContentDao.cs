using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Database;

namespace Context.Dao
{
    public class ContentDao
    {
        public Content GetMainContentOfCategory(int idCategory)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents.FirstOrDefault(c => c.CategoryID == idCategory);

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public Content GetContentByIdContent(int id)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents.FirstOrDefault(c => c.Id == id && c.Status == true);

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public Content GetContentByIdContentAll(int id)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents.FirstOrDefault(c => c.Id == id);

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public bool Insert(Content content)
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var data = content;
                    context.Contents.Add(data);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Update(Content content)
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var data = context.Contents.Find(content.Id);

                    if (data != null)
                    {
                        context.Entry(data).CurrentValues.SetValues(content);
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
            if (id <= 0)
            {
                return false;
            }

            using (var context = new hscbEntities())
            {
                try
                {
                    var data = context.Contents.Find(id);

                    if (data != null)
                    {
                        context.Entry(data).State = EntityState.Deleted;
                        context.SaveChanges();

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public List<Content> GetAll()
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents.ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public List<Content> GetByCategory(int idCategory)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents
                        .OrderByDescending(c => c.CreatedDate).Where(c => c.CategoryID == idCategory).ToList();

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }
        public Content GetNewContent(int idCategory)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents.Where(c => c.CategoryID == idCategory).OrderByDescending(c => c.ModifiedDate).FirstOrDefault();

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public List<Content> GetOldContents(int idCategory)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents.Where(c => c.CategoryID == idCategory).OrderByDescending(o => o.CreatedDate).Skip(1).Take(2).ToList<Content>();

                    return response;
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }
    }
}
