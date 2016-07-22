using ITL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITL.Controllers
{
    public class SystemDefinitionController : Controller
    {
        //
        // GET: /SystemDefinition/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationMenu()
        {
            return View();
        }
        public ActionResult Module()
        {
            return View();
        }
	}
}