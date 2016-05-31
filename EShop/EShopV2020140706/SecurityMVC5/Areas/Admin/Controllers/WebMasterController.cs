using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecurityMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityMVC5.Controllers
{
    public class WebMasterController : SecurityController
    {
        public ActionResult Index()
        {
            ViewBag.Users = sdb.Users.Where(u => u.Roles.Count > 0);
            ViewBag.Roles = sdb.Roles;
            
            ViewBag.OldRoleName = new SelectList(sdb.Roles, "Name", "Name");
            return View();
        }
        /*
         * ========== ROLE ==========
         */
        public ActionResult AddRole(String NewRoleName)
        {
            var role = new ApplicationRole
            {
                Name = NewRoleName
            };
            sdb.Roles.Add(role);
            sdb.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RemoveRole(String OldRoleName)
        {
            var role = sdb.Roles.Single(r => r.Name == OldRoleName);
            sdb.Roles.Remove(role);
            sdb.SaveChanges();

            return RedirectToAction("Index");
        }

        /*
         * ========== USER ========
         */
        public ActionResult AddUser(String UserName, String Password, String[] Roles)
        {
            var user = new ApplicationUser
            {
                UserName = UserName
            };
            var result = UserManager.Create(user, Password);

            if (result.Succeeded)
            {
                foreach (var role in Roles)
                {
                    UserManager.AddToRole(user.Id, role);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveUser(String UserName)
        {
            var user = UserManager.FindByName(UserName);

            foreach (var ur in user.Roles.ToList())
            {
                UserManager.RemoveFromRole(user.Id, ur.Role.Name);
            }

            sdb.Users.Remove(user);

            sdb.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateRole(String RoleName, bool Status, String UserName)
        {
            var user = UserManager.FindByName(UserName);
            if (Status == true)
            {
                UserManager.AddToRole(user.Id, RoleName);
            }
            else
            {
                UserManager.RemoveFromRole(user.Id, RoleName);
            }
            return Content("Update successfully !");
        }
	}
}