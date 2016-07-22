using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITL.Models;

namespace ITL.Controllers
{
    public class ApplicationMenuController : Controller
    {
        ApplicationMenuModel application_menu_object = new ApplicationMenuModel();

        //
        // GET: /ApplicationMenu/
        public ActionResult Index()
        {
            return View();
        }

        public List<ApplicationMenuModel> getAll()
        {
            return application_menu_object.getAll();
        }
	}
}