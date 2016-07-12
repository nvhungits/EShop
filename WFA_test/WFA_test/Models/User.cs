using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WFA_test.ServerToTest;

namespace WFA_test.Models
{
    class User:sysTable
    {
        Data d = new Data();
        public String UserName { set; get; }
        public String Password { set; get; }
        public String Full_Name { set; get; }
        public String Email { set; get; }
        public String Country_Code { set; get; }
        public String Business_Phone { set; get; }
        public Department Department
        {
            set;
            get;
        }
        public Company Company
        {
            set;
            get;
        }
        public DateTime Last_Login { set; get; }
        public String Role { set; get; }
        public bool Active { set; get; }
        public User() { }
        public User(String usrn, String pwd, String r, bool active)
        {
            this.UserName = usrn;
            this.Password = pwd;
            this.Role = r;
            this.Active = active;
        }

        public List<User> getAllUser()
        {
            IEnumerable<User> lst_u = from obj_u in d.UserItems() select obj_u;
            return lst_u.ToList();
        }
        public User FindUserBy(String UserName, String Password)
        {
            IEnumerable<User> lst_u = from obj_u in this.getAllUser()
                where obj_u.UserName == UserName && obj_u.Password == Password
                select obj_u;
            return lst_u.ToList().Single();
        }
    }
}
