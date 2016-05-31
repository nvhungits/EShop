using CsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopV2020140706.Controllers
{
    public class CsQueryController : Controller
    {
        //
        // GET: /CsQuery/
        public ActionResult Index()
        {
            var dom = CQ.CreateFromUrl("http://tuoitre.vn/tin/phap-luat/20140921/nguyen-chu-tich-agribank-bi-bat/648532.html");
            CQ divs = dom.Select("div.fck");
            string html = divs.RenderSelection();
            return Content(html);
        }
	}
}