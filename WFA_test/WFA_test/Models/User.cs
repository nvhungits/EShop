using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WFA_test.ServerToTest;

namespace WFA_test.Models
{
    class User
    {
        Data d = new Data();
        public String UserName { set; get; }
        public String Password { set; get; }
        public bool Active { set; get; }
        public User() { }
        public User(String usrn, String pwd, bool active)
        {
            this.UserName = usrn;
            this.Password = pwd;
            this.Active = active;
        }

        public List<User> getAllUser()
        {
            IEnumerable<User> lst_u = from obj_u in d.UserItems() select obj_u;
            return lst_u.ToList();
        }
        public int FindUserBy(String UserName, String Password)
        {
            IEnumerable<User> lst_u = from obj_u in this.getAllUser()
                where obj_u.UserName == UserName && obj_u.Password == Password
                select obj_u;
            if (lst_u.Count() > 0)
                return 2;
            else
            {
                lst_u = from obj_u in this.getAllUser()
                        where obj_u.UserName == UserName && obj_u.Password != Password
                        select obj_u;
                if (lst_u.Count() > 0)
                    return 1;
            }
            return 0;
        }
    }
}
