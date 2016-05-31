using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SecurityMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityMVC5.Controllers
{
    public class SecurityController : Controller
    {
        public ApplicationDbContext sdb = new ApplicationDbContext();

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public SecurityController()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sdb));
        }

        public void SignOut()
        {
            AuthManager.SignOut();
        }

        public void SignIn(ApplicationUser user, bool isPersistent)
        {
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }
	}
}