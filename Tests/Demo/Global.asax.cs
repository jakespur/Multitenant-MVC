using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcMultiTenant.Demo
{
    using Multitenant.MvcHelpers;
    using Multitenant.MvcHelpers.Registry;

    using MvcMultiTenant.Demo.App_Start;
    using MvcMultiTenant.Demo.Registry;

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
                    x.AddRegistry<MvcRegistry>();
                    x.Scan(y =>
                        {
                            y.TheCallingAssembly();
                            y.Convention<SharedControllerConvention>();    
                        });
            });
            
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new TenantViewEngine());
            ControllerBuilder.Current.SetControllerFactory(new TenantControllerFactory());
        }
    }
}