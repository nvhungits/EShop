using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityMVC5.Areas.Admin.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult byCategory()
        {
            return Content("byCategory");
        }

        public ActionResult bySupplier()
        {
            return View("bySupplier");
        }
	}
}