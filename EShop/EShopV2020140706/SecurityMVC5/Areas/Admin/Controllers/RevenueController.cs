using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityMVC5.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        public ActionResult byCategory()
        {
            return Content("byCategory");
        }

        public ActionResult bySupplier()
        {
            return Content("bySupplier");
        }

        public ActionResult byCustomer()
        {
            return Content("byCustomer");
        }

        public ActionResult byYear()
        {
            return Content("byYear");
        }

        public ActionResult byQuarter()
        {
            return Content("byQuarter");
        }

        public ActionResult byMonth()
        {
            return Content("byMonth");
        }
	}
}