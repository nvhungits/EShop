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
        UserModel user_object = new UserModel();

        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        public List<UserModel> getAll()
        {
            return user_object.getAll();
        }
	}
}