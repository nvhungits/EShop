﻿using System;
using System.Collections.Generic;
using System.Linq;
using WFA_test.Models;

namespace WFA_test.Controllers
{
    class UserController
    {
        User u = new User();
        public List<User> getAllUser()
        {
            try
            {
                return u.getAllUser();
            }
            catch
            {
                return null;
            }
        }
        public int FindUserBy(String UserName, String Password)
        {
            try
            {
                return u.FindUserBy(UserName, Password);
            }
            catch
            {
                return 0;
            }
        }
    }
}
