using System.Web.Mvc;
using OpenSupport.Core.Services;
using OpenSupport.Web.ViewModels;
using WebMatrix.WebData;
using OpenSupport.DataAccess;
using System;

namespace OpenSupport.Web.Controllers
{
    public class SetupController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new SetupViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SetupViewModel model)
        {
            try
            {
                WebSecurity.InitializeDatabaseConnection(model.Configuration.ConnectionString, "System.Data.SqlClient", "UserProfile", "UserId", "UserName", true);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("__FormValidation", "Failed to initialize database, check connection string");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            WebSecurity.CreateUserAndAccount(model.Configuration.AdminUserName, model.Configuration.AdminPassword);
            WebSecurity.Login(model.Configuration.AdminUserName, model.Configuration.AdminPassword);

            SiteManager.SaveSite(model.Configuration);

            return RedirectToAction("Index", "Home");
        }
    }
}