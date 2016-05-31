using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopV2020140706.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var f = Request.Files["uplPhoto"];
            f.SaveAs(Server.MapPath("~/Test/" + f.FileName));
            return Content(f.FileName);
        }
	}
}