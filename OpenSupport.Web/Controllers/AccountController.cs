using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OpenSupport.Core.Filters;
using OpenSupport.Core.Services;
using OpenSupport.Dashboard.Services;
using OpenSupport.Dashboard.ViewModels;
using OpenSupport.Models.Entities;
using WebMatrix.WebData;

namespace OpenSupport.Web.Controllers
{
    [InitializeMembership]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationSerivce;

        public AccountController(IAuthenticationService authenticationSerivce)
        {
            _authenticationSerivce = authenticationSerivce;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!Membership.ValidateUser(model.UserName, model.Password))
            {
                ModelState.AddModelError("__Form", "Authentication Failed");
                return View(model);
            }
            
            WebSecurity.Login(model.UserName, model.Password);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            User newUser;
            
            if (model.Password != model.ConfirmPassword)
                ModelState.AddModelError("ConfirmPassword", "Passwords must match");

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                newUser = _authenticationSerivce.CreateUser(model.UserName, model.Password);
            }
            catch
            {
                ModelState.AddModelError("__Form", "There was an error creating the account, please try again");
                return View(model);
            }

            _authenticationSerivce.Login(model.UserName, model.Password);

            return RedirectToAction("Index", "Home");
        }
    }
}
