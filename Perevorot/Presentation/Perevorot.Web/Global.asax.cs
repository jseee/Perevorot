﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Perevorot.Web.Helpers;
using Perevorot.Web.Helpers.jQuery.DataTables.Mvc;
using Perevorot.Web.ResourceLocator;

namespace Perevorot.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public override void Init()
        {
            IoC.RegisterAll();
            base.Init();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Lets MVC know that anytime there is a JQueryDataTablesModel as a parameter in an action to use the
            // JQueryDataTablesModelBinder when binding the model.
            ModelBinders.Binders.Add(typeof(JQueryDataTablesModel), new JQueryDataTablesModelBinder());
        }


        protected void Application_End()
        {
            IoC.Dispose();
        }
    }
}