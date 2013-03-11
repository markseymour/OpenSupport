using System.Web.Mvc;
using OpenSupport.Core.Services;
using OpenSupport.Web.ViewModels;
using WebMatrix.WebData;
using OpenSupport.DataAccess;

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

            //WebSecurity.CreateAccount(model.Configuration.AdminUser.UserName, model.Configuration.AdminUser.Password);
            //WebSecurity.Login(model.Configuration.AdminUser.UserName, model.Configuration.AdminUser.Password);

            return RedirectToAction("Index", "Home");
        }
    }
}