using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_MVC5Bootstrap_Intellivue.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dasboard/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Management()
        {
            return View();
        }

        public ActionResult Viewer()
        {
            return View();
        }
	}
}