using OpenSupport.Web.Tools;
using System.Web;
using System.Web.Optimization;

namespace OpenSupport.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(GetLessBundle());
            bundles.Add(GetSetupBundle());
            bundles.Add(GetLoginBundle());
        }

        public static Bundle GetLessBundle()
        {
            var lessBundle = new Bundle("~/Styles/less").IncludeDirectory("~/Styles", "*.less");
            lessBundle.Transforms.Add(new LessTransformer());

            return lessBundle;
        }

        public static Bundle GetSetupBundle()
        {
            var setupBundle = new Bundle("~/Styles/AdHocStyles/setup").IncludeDirectory("~/Styles/AdHocStyles", "Setup.less");
            setupBundle.Transforms.Add(new LessTransformer());

            return setupBundle;
        }

        public static Bundle GetLoginBundle()
        {
            var loginBundle = new Bundle("~/Styles/AdHocStyles/authentication").IncludeDirectory("~/Styles/AdHocStyles", "Authentication.less");
            loginBundle.Transforms.Add(new LessTransformer());

            return loginBundle;
        }
    }
}