using SecurityMVC5.Areas.Admin.Controllers;
using SecurityMVC5.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityMVC5.Models
{
    public class SecurityDbInitializer
    {
        public static void initiate()
        {
            ApplicationDbContext sdb = new ApplicationDbContext();

            var controllers = new[] { 
                typeof(CategoryController),
                typeof(ProductController),
                typeof(RevenueController),
                typeof(InventoryController),
                typeof(WebActionController),
                typeof(WebMasterController),
                typeof(PermissionController)

            };
            foreach (var c in controllers)
            {
                var methods = c.GetMethods();
                foreach (var m in methods)
                {
                    if (m.ReturnType == typeof(ActionResult))
                    {
                        sdb.WebActions.Add(new WebAction
                        {
                            Name = m.Name,
                            Controller = c.Name.Replace("Controller", "")
                        });
                    }
                }
            }
            sdb.SaveChanges();
            sdb.Dispose();
        }
    }
}