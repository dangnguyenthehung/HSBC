using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Database;
using Context.Utilities;
using PagedList;

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

        public IEnumerable<Image> GetProductImagesAll(int idCategory, int page, int pageSize)
        {
            try
            {
                using (var context = new hscbEntities())
                {
                    var response = context.Get_Product_Images_All(idCategory).ToList();

                    var result = response.Select(p => p.Cast<Image>()).ToList();

                    return result.OrderBy(x => x.IdContent).ToPagedList(page, pageSize);
                }
            }
            catch (Exception ex)
            {
                //
                return null;
            }
        }

        public bool Insert(Image image)
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var data = image;
                    context.Images.Add(data);
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Update(Image image)
        {
            using (var context = new hscbEntities())
            {
                try
                {
                    var data = context.Images.Find(image.IdImage);

                    if (data != null)
                    {
                        context.Entry(data).CurrentValues.SetValues(image);
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

    }
}
