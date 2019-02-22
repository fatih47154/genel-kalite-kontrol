using KaliteGiris.Web.App_Start;
using KaliteGiris.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace KaliteGiris.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalFilters.Filters.Add(new _SecurityFilter());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

    }
}
