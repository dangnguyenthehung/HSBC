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
    }
}
