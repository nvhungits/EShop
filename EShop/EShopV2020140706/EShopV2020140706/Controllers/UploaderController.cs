using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopV2020140706.Controllers
{
    public class UploaderController : Controller
    {
        //
        // GET: /Uploader/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var f = Request.Files["photo"];
            f.SaveAs(Server.MapPath("~/photos/" + f.FileName));
            return Content(f.FileName);
        }
	}
}