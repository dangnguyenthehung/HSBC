using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Database;
using Context.Utilities;

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

        public bool ChangePassword(long userId, string passWord, string newPassword)
        {
            var data = db.Users.Find(userId);
            
            if (data != null && data.PassWord == passWord)
            {
                var user = data.Cast<User>();

                user.PassWord = newPassword;

                data.PassWord = newPassword;
                db.Entry(data).CurrentValues.SetValues(user);
                db.SaveChanges();


                return true;
            }

            return false;
        }
    }
}
