using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITL_v2.Models;

namespace ITL_v2.Controllers
{
    public class ModuleController : Controller
    {
        //
        // GET: /Module/
        public ActionResult Index()
        {
            return View();
        }

        public List<_Module> getAll()
        {
            return new _Module().getAll();
        }
        public List<_Module> getByApplicationMenuID(String ID)
        {
            return new _Module().getByApplicationMenuID(ID);
        }
	}
}