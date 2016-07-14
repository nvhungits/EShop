using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITL.Models;

namespace ITL.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        User u = new User();
        public IEnumerable<User> getAllUser()
        {
            return u.getAllUser();
        }
	}
}