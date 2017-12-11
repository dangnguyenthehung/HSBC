using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Database;

namespace Context.Dao
{
    public class UserDao
    {
        private hscbEntities db = null;

        public UserDao()
        {
            db = new hscbEntities();
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }

        public UserLogin Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName && x.PassWord == passWord);

            if (result == null)
            {
                return null;
            }
            
            return new UserLogin()
            {
                UserID = result.ID,
                UserName = result.UserName
            };
        }
    }
}
