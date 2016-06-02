using ITLNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITLNow.Domain
{
    public class Data
    {
        public IEnumerable<ApplicationMenu> ApplicationMenuItems()
        {
            var menu = new List<ApplicationMenu>();
            
            menu.Add(new ApplicationMenu { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-dashboard fa-fw", status = true, isParent = false, parentId = 0 });
            menu.Add(new ApplicationMenu { Id = 2, nameOption = "Charts", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new ApplicationMenu { Id = 3, nameOption = "Flot Charts", controller = "Home", action = "FlotCharts", status = true, isParent = false, parentId = 2 });
            menu.Add(new ApplicationMenu { Id = 4, nameOption = "Morris.js Charts", controller = "Home", action = "MorrisCharts", status = true, isParent = false, parentId = 2 });
            menu.Add(new ApplicationMenu { Id = 5, nameOption = "Tables", controller = "Home", action = "Tables", imageClass = "fa fa-table fa-fw", status = true, isParent = false, parentId = 0 });
            menu.Add(new ApplicationMenu { Id = 6, nameOption = "Forms", controller = "Home", action = "Forms", imageClass = "fa fa-edit fa-fw", status = true, isParent = false, parentId = 0 });
            menu.Add(new ApplicationMenu { Id = 7, nameOption = "UI Elements", imageClass = "fa fa-wrench fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new ApplicationMenu { Id = 8, nameOption = "Panels and Wells", controller = "Home", action = "Panels", status = true, isParent = false, parentId = 7 });
            menu.Add(new ApplicationMenu { Id = 9, nameOption = "Buttons", controller = "Home", action = "Buttons", status = true, isParent = false, parentId = 7 });
            menu.Add(new ApplicationMenu { Id = 10, nameOption = "Notifications", controller = "Home", action = "Notifications", status = true, isParent = false, parentId = 7 });
            menu.Add(new ApplicationMenu { Id = 11, nameOption = "Typography", controller = "Home", action = "Typography", status = true, isParent = false, parentId = 7 });
            menu.Add(new ApplicationMenu { Id = 12, nameOption = "Icons", controller = "Home", action = "Icons", status = true, isParent = false, parentId = 7 });
            menu.Add(new ApplicationMenu { Id = 13, nameOption = "Grid", controller = "Home", action = "Grid", status = true, isParent = false, parentId = 7 });
            menu.Add(new ApplicationMenu { Id = 14, nameOption = "Multi-Level Dropdown", imageClass = "fa fa-sitemap fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new ApplicationMenu { Id = 15, nameOption = "Second Level Item", status = true, isParent = false, parentId = 14 });
            menu.Add(new ApplicationMenu { Id = 16, nameOption = "Sample Pages", imageClass = "fa fa-files-o fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new ApplicationMenu { Id = 17, nameOption = "Blank Page", controller = "Home", action = "Blank", status = true, isParent = false, parentId = 16 });
            menu.Add(new ApplicationMenu { Id = 18, nameOption = "Login Page", controller = "Home", action = "Login", status = true, isParent = false, parentId = 16 });


            /*System definition*/
            menu.Add(new ApplicationMenu { Id = 19, nameOption = "System Definition", status = true, isParent = true, parentId = 0, imageClass = "fa fa-cogs" });
            menu.Add(new ApplicationMenu { Id = 20, nameOption = "Application Menus", controller = "SystemDefinition", action = "ApplicationMenu" ,status = true, isParent = false, parentId = 19});


            return menu.ToList();
        }

        public IEnumerable<tables> dbObjectItems()
        {
            var dbob = new List<tables>();
            dbob.Add(new tables { Id = 1, title = "Application Menu", name = "application_menu", active = true});
            return dbob.ToList();
        }
    }
}