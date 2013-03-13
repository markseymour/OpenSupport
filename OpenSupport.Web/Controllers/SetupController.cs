using System.Data.Entity;
using System.Web.Mvc;
using OpenSupport.Core.Models;
using OpenSupport.Core.Services;
using OpenSupport.DataAccess;
using OpenSupport.DataAccess.Tools;
using OpenSupport.Models.Entities;
using OpenSupport.Web.ViewModels;


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
            SiteManager.SaveSite(model.Configuration);

            using (var sessionFactory = OpenSupportSessionFactory.BuildInitialDatabase())
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var user = new User
                    {
                        UserName = model.Configuration.AdminUserName,
                        Password = PasswordHash.CreateHash(model.Configuration.AdminPassword)
                    };

                    var transaction = session.BeginTransaction();

                    session.Save(user);
                    transaction.Commit();
                }
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}