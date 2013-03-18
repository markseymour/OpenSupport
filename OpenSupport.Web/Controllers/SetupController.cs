using System;
using System.Data.Entity;
using System.Web.Mvc;
using OpenSupport.Core.Models;
using OpenSupport.Core.Services;
using OpenSupport.DataAccess;
using OpenSupport.DataAccess.Tools;
using OpenSupport.Models.Entities;
using OpenSupport.Web.ViewModels;
using WebMatrix.WebData;


namespace OpenSupport.Web.Controllers
{
    public class SetupController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var siteSettings = SiteManager.CurrentSite();

            var model = new SetupViewModel();
            
            if(siteSettings != null)
                model.Configuration = siteSettings;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SetupViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var adminUser = new User
            {
                UserName = model.Configuration.AdminUserName,
                Password = PasswordHash.CreateHash(model.Configuration.AdminPassword)
            };

            try
            {
                using (var sessionFactory = OpenSupportSessionFactory.CreateSessionFactory(model.Configuration.ConnectionString))
                {
                    SiteManager.SaveSite(model.Configuration);
                    using (var session = sessionFactory.OpenSession())
                    {


                        var userMembership = new UserMembership
                        {
                            Role = Role.Administrator,
                            User = adminUser
                        };

                        var transaction = session.BeginTransaction();

                        session.Save(adminUser);
                        session.Save(userMembership);
                        transaction.Commit();
                    }
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError("__FormValidation", e.InnerException.Message);
                return View(model);
            }

            
            WebSecurity.Login(model.Configuration.AdminUserName, model.Configuration.AdminPassword);

            return RedirectToAction("Index", "Home");
        }
    }
}