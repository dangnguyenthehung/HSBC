using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Context.Dao;
using Context.Database;

namespace HSCB.SingleTon
{
    public class CategorySingleTon
    {
        private CategorySingleTon()
        {
            //
        }

        private static List<Category> _listCategory = null;

        private  CategorySingleTon _categorySingleTon = new CategorySingleTon();

        private static void GetData()
        {
            var helper = new CategoryDao();
            _listCategory = helper.GetAll();
        }

        public static void UpdateData()
        {
            GetData();
        }

        public static List<Category> GetAllCategories()
        {
            if (_listCategory == null)
            {
                GetData();
            }

            return _listCategory;
        }

        public static string GetName(int id)
        {
            if (_listCategory == null)
            {
                GetData();
            }

            return _listCategory?.Find(c => c.ID == id)?.Name ?? "Không có";
        }

        public static List<Category> GetChildCategories(int id)
        {
            if (_listCategory == null)
            {
                GetData();
            }

            return _listCategory?.Where(c => c.ParentID == id).ToList();
        }

        public static Category GetById(int id)
        {
            if (_listCategory == null)
            {
                GetData();
            }

            return _listCategory?.SingleOrDefault(c => c.ID == id);
        }
    }
}