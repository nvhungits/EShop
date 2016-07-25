using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITL_v2.Models;

namespace ITL_v2.Controllers
{
    public class ApplicationMenuController : Controller
    {
        //
        // GET: /ApplicationMenu/
        public ActionResult Index()
        {
            return View();
        }
        _ApplicationMenu application_menu_object = new _ApplicationMenu();
        public List<_ApplicationMenu> getAll()
        {
            return application_menu_object.getALl();
        }
	}
}