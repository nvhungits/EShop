using System;
using System.Collections.Generic;
using System.Linq;
using WFA_test.Controllers;

namespace WFA_test.Controllers
{
    class AccountController
    {
        UserController u_ctrl = new UserController();
        public String Login(String UserName, String Password){
            int res = u_ctrl.FindUserBy(UserName, Password);
            if(res == 0){
                return "UserName is not exist.";
            }
            else{
                if (res == 1)
                {
                    return "Password is wrong.";
                }
            }
            return "Login Successful.";
        }
    }
}
