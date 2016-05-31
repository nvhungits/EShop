using SecurityMVC5.Controllers;
using System.Web;
using System.Web.Mvc;

namespace EShopV2020140706
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SecurityActionFilterAttribute());
        }
    }
}
