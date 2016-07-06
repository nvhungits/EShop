using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA_test.Models;

namespace WFA_test.ServerToTest
{
    class Data
    {
        public IEnumerable<User> UserItems()
        {
            List<User> Users = new List<User>();

            Users.Add(new User("admin","admin",true));
            Users.Add(new User("user", "user", true));
            Users.Add(new User("guest", "123", false));

            return Users.ToList();
        }

        public IEnumerable<Table> TableItems()
        {
            List<Table> Tables = new List<Table>();

            Tables.Add(new Table("Table1",  true));
            Tables.Add(new Table("Table2", true));
            Tables.Add(new Table("Table3", true));
            Tables.Add(new Table("Table4", true));
            Tables.Add(new Table("Table5", true));
            Tables.Add(new Table("Table6", true));

            return Tables.ToList();
        }
    }
}
