using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA_test.ServerToTest;

namespace WFA_test.Models
{
    class User
    {
        Data d = new Data();
        public String UserName { set; get; }
        public String Password { set; get; }
        public bool Active { set; get; }

        public User() { 

}

        public User(String usrn, String pwd, bool active)
        {
            this.UserName = usrn;
            this.Password = pwd;
            this.Active = active;
        }

        public IEnumerable<User> getAll()
        {
            IEnumerable<User> u = from user in d.UserItems() select user;
            return u.ToList();
        }
        public bool validate(String UserName, String Password)
        {
            IEnumerable<User> lstUser = from u in this.getAll() where u.UserName == UserName && u.Password == Password select u;
            if (lstUser.Count() > 0)
                return true;
            return false;
        }
    }
}
