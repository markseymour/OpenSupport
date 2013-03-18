using System.Web.Mvc;
using System.Web.Routing;
using OpenSupport.Core.Services;

namespace OpenSupport.Setup
{
    public class InializeControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (!SiteManager.IsSiteSetup())
            {
                requestContext.RouteData.Values["action"] = "Index";
                requestContext.RouteData.Values["controller"] = "Setup";
                return base.CreateController(requestContext, "Setup");
            }

            try
            {
                return base.CreateController(requestContext, controllerName);
            } 
            catch
            {
                Bootstrapper.Run();
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}
