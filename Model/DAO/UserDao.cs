using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDao
    {
        OnlineShopDbContext db = null;

        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Login(string username, string pass)
        {
            var result = db.Users.Count(x => x.Username == username && x.Password == pass);
            return result > 0 ? true : false;
        }
    }
}
