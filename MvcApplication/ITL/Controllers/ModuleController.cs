using ITL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITL.Controllers
{
    public class ModuleController : Controller
    {
        ModuleModel module_object = new ModuleModel();

        //
        // GET: /Module/
        public ActionResult Index()
        {
            return View();
        }

        public List<ModuleModel> getAll()
        {
            return module_object.getAll();
        }
        public List<ModuleModel> getByApplicationMenuId(String ID)
        {
            return module_object.getByApplicationMenuId(ID);
        }
	}
}