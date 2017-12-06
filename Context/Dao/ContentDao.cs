﻿using System;
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
                    var response = context.Contents.FirstOrDefault(c => c.CategoryID == id);

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
    }
}
