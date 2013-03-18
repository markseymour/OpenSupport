using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OpenSupport.Utility.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MenuLink(this HtmlHelper helper, string linkText, string action, string controller)
        {
            var currentAction = helper.ViewContext.RouteData.Values["action"].ToString();
            var currentController = helper.ViewContext.RouteData.Values["controller"].ToString();

            if (action == currentAction && controller == currentController)
            {
                return helper.ActionLink(
                    linkText,
                    action,
                    controller,
                    null,
                    new { @class = "active" }
                    );
            }

            return helper.ActionLink(linkText, action, controller);
        }
    }
}
