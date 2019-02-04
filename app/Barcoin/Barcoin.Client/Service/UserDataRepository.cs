using System.Collections.Generic;
using System.Linq;
using Barcoin.Client.Helper;
using Barcoin.Client.Model;
using SqlKata.Execution;

namespace Barcoin.Client.Service
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly QueryFactory db;

        public UserDataRepository()
        {
            DbHelper helper = new DbHelper();

            db = helper.GetFactory();
        }

        public void Add(User item)
        {
            db.Query("user").Insert(new
            {
                item.Firstname,
                item.Lastname,
                item.Username,
                item.Password,
                item.Salt,
                item.Address,
                item.Timestamp
            });
        }

        public void Delete(int id)
        {
            db.Query("user").Where("id", id).Delete();
        }

        public User Get(int id)
        {
            return Get().Find(u => u.Id == id);
        }

        public List<User> Get()
        {
            return db.Query("user").Get<User>().ToList();
        }

        public User Get(string username)
        {
            return Get().Find(u => u.Username.Equals(username));
        }

        public void Update(User item)
        {
            db.Query("user").Where("id", item.Id).Update(new
            {
                item.Firstname,
                item.Lastname,
                item.Username,
                item.Password,
                item.Salt
            });
        }
    }
}
