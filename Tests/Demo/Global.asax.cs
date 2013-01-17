using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMultiTenant.Demo
{
    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.Interfaces.Resolvers;
    using Multitenant.Core.Interfaces.Services;
    using Multitenant.MvcHelpers;
    using Multitenant.Repositories;
    using Multitenant.Services;

    using MvcMultiTenant.Demo.App_Start;

    using StructureMap;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ObjectFactory.Configure(x =>
                {
                    x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                    x.For<ITenantRepository>().Use<TenantXmlRepository>();
                    x.For<ITenantService>().Use<TenantService>();
                    x.For<ICurrentTenantResolver>().Use<UrlTenentResolver>();
                });

            ViewEngines.Engines.Add(ObjectFactory.GetInstance<TenantViewEngine>());
        }
    }
}