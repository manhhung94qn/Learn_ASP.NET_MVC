using Model.EF;
using System.Linq;
namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public User GetById(string us)
        {
            return db.Users.FirstOrDefault(x=>x.Username == us);
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Login(string us, string pas)
        {
            var result = db.Users.Count(x => x.Username == us && x.Password == pas);
            return result > 0 ? true : false;
        }
    }
}
