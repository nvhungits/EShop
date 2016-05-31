using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopV2020140706.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Search()
        {
            var name = Request["term"];

            var data = db.Products
                .Where(p => p.Name.Contains(name))
                .Select(p=>p.Name).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var model = db.Categories
                .Where(c => c.Products.Count >= 5)
                .OrderBy(c => Guid.NewGuid()).ToList()
                .Take(4);

            ViewBag.Suppliers = db.Suppliers
                .Where(c => c.Products.Count >= 5)
                .OrderBy(c => Guid.NewGuid()).ToList();

            return View(model);
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

        EShopV20DbContext db = new EShopV20DbContext();
        public ActionResult Category()
        {
            var model = db.Categories;
            return PartialView("_Category", model);
        }
        public ActionResult Supplier()
        {
            var model = db.Suppliers;
            return PartialView("_Supplier", model);
        }
    }
}