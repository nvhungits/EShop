using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITL.Models;

namespace ITL.Controllers
{
    public class ViewRuleController : Controller
    {
        ViewRuleModel view_rule_object = new ViewRuleModel();
        //
        // GET: /ViewRule/
        public ActionResult Index()
        {
            return View();
        }

        public List<ViewRuleModel> getAll()
        {
            return view_rule_object.getAll();
        }
        public List<ViewRuleModel> getByTableRef(String TableRef)
        {
            return view_rule_object.getByTableRef(TableRef);
        }
	}
}