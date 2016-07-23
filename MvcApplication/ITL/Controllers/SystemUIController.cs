using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITL.Controllers
{
    public class SystemUIController : Controller
    {
        //
        // GET: /SystemUI/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewRule()
        {
            return View();
        }
	}
}