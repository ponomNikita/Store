using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Store.Infrastructure.Logging;

namespace Store
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogger _logger = LoggerManager.GetLogger(typeof(MvcApplication));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();
            _logger.Info("Start application");
        }
    }
}
