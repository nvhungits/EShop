using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_MVC5Bootstrap_Intellivue.Controllers
{
    public class AdministratorController : Controller
    {
        //
        // GET: /Administrator/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorization()
        {
            return View();
        }

        public ActionResult ContentManagement()
        {
            return View();
        }
	}
}