using Admin_MVC5Bootstrap_Intellivue.Domain;
using Admin_MVC5Bootstrap_Intellivue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_MVC5Bootstrap_Intellivue.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Index()
        {
            var data = new Data();
            return PartialView("_Navbar", data.navbarItems().ToList());
        }
    }
}