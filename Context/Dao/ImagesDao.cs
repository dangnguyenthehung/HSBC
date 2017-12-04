using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Database;

namespace Context.Dao
{
    public class ImagesDao
    {
        public List<Image> GetImages (int id)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Images.Where(p => p.IdContent == id).ToList();

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
