using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA_test.Models;

namespace WFA_test.Controllers
{
    class UserController
    {
        User u = new User();
        public bool Validate(String UserName, String Password)
        {
            return u.validate(UserName,Password);
        }
    }
}
