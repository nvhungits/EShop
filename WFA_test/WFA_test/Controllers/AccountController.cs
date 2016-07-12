using System;
using System.Collections.Generic;
using System.Linq;
using WFA_test.Controllers;
using WFA_test.Models;

namespace WFA_test.Controllers
{
    class AccountController
    {
        UserController u_ctrl = new UserController();
        public User Login(String UserName, String Password){
            return u_ctrl.FindUserBy(UserName, Password);
        }
    }
}
