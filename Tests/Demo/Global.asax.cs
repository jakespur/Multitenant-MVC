using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMultiTenant.Demo
{
    using System;
    using System.Diagnostics;
    using System.Net.Mime;

    using Microsoft.Web.Administration;

    using Multitenant.Core.Helpers;
    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.Interfaces.Resolvers;
    using Multitenant.Core.Interfaces.Services;
    using Multitenant.MvcHelpers;
    using Multitenant.Repositories;
    using Multitenant.Services;
    using Multitenant.UnitTests.Helpers;

    using MvcMultiTenant.Demo.App_Start;

    using StructureMap;

    using Site = System.Security.Policy.Site;

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

            this.OutputServers();

            ObjectFactory.Configure(x =>
                {
                    x.For<HttpContextBase>().Use(() => new HttpContextWrapper(HttpContext.Current));
                    x.For<ITenantRepository>().Use<TenantXmlRepository>().Ctor<string>("tenantConfigPath").Is(App.Path + "\\Tenant.Config");
                    x.For<ITenantService>().Use<TenantService>();
                    x.For<ICurrentTenantResolver>().Use<UrlTenentResolver>().Ctor<string>("hostName").Is(HttpRuntime.AppDomainAppPath);
                });

            ViewEngines.Engines.Add(ObjectFactory.GetInstance<TenantViewEngine>());
        }

        public void OutputServers()
        {
            using (var serverManager = new ServerManager()) 
            { 
                var sites = serverManager.Sites; 
                foreach (var site in sites) 
                { 
                    Debug.WriteLine(site.Name);
                }
            }
        }
    }
}