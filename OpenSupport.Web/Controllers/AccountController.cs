using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OpenSupport.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
