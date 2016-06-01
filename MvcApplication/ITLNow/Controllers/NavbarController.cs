﻿using ITLNow.Domain;
using ITLNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITLNow.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Index()
        {
            var data = new Data();
            return PartialView("_Navbar", data.navbarItems().ToList());
        }
    }
}