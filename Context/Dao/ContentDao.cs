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
    }
}
