using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityMVC5.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return Content("Index");
        }

        public ActionResult Insert()
        {
            return Content("Insert");
        }

        public ActionResult Update()
        {
            return Content("Update");
        }

        public ActionResult Delete()
        {
            return Content("Delete");
        }

        public ActionResult Edit()
        {
            return Content("Edit");
        }
	}
}