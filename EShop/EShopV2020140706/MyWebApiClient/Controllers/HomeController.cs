using MyWebApiClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApiClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Purchase()
        {
            var api = new WebApiClient<Account>();
            var data = new Account{
                Id="nghiem",
                Balance=600
            };
            api.Put("/api/Bank/nn", data);
            return Content("Đã thanh toán");
        }

        public ActionResult Bootstrap()
        {
            return View();
        }

        public ActionResult Index()
        {
            var api = new WebApiClient<Student>();
            var data = api.GetAll("api/Student");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}