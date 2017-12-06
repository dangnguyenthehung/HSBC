using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Database;

namespace Context.Dao
{
    public class ContentDao
    {
        public Content GetContent(int id)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Contents.SingleOrDefault(c => c.CategoryID == id);

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
                    var response = context.Contents.LastOrDefault(c => c.CategoryID == idCategory);

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
                    var response = context.Contents.Where(c => c.CategoryID == idCategory).OrderByDescending(o => o.CreatedDate).Take(2).ToList();

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
