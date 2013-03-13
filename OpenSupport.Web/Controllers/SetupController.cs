using System.Data.Entity;
using System.Web.Mvc;
using OpenSupport.Core.Services;
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
            return RedirectToAction("Index", "Home");
        }
    }
}