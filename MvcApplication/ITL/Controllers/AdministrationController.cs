using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITL.Controllers
{
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserList()
        {
            UserController uctrl = new UserController();
            return View(uctrl.getAllUser());
        }
	}
}