using System;
using System.Threading;
using System.Web.Mvc;
using OpenSupport.Core.Services;
using OpenSupport.Models.Entities;
using WebMatrix.WebData;

namespace OpenSupport.Core.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeMembership : ActionFilterAttribute
    {
        private static OpenSupportMemebershipInitiazer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized , ref _initializerLock);
        }


        private class OpenSupportMemebershipInitiazer
        {
            public OpenSupportMemebershipInitiazer()
            {
                WebSecurity.InitializeDatabaseConnection(SiteManager.CurrentSite().ConnectionString, typeof(User).Name, "Id", "UserName", false);
            }
        }
    }
}