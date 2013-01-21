using System;

namespace Multitenant.MvcHelpers
{
    using System.Web.Mvc;

    using Multitenant.Core.Interfaces.Resolvers;
    using Multitenant.Core.ValueObjects;

    using StructureMap;

    public class TenantViewEngine : RazorViewEngine
    {
        private ActiveTenant _tenant;
        private const string TenantBaseView = "~/Tenants/{TenantName}/";
        const string TenantViewPath = TenantBaseView + "Views/{1}/{0}";
        const string SharedPath = TenantBaseView + "Shared/Views/{0}";

        public TenantViewEngine()
        {
            this.ViewLocationFormats = new string[] { TenantViewPath, SharedPath };
            this.PartialViewLocationFormats = new string[] { TenantViewPath, SharedPath };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var physicalPath = controllerContext.HttpContext.Server.MapPath(partialPath);
            return base.CreatePartialView(controllerContext, physicalPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalPath = controllerContext.HttpContext.Server.MapPath(masterPath);
            return base.CreatePartialView(controllerContext, physicalPath);
        }

        protected ActiveTenant ActiveTenant
        {
            get
            {
                return _tenant ?? (_tenant = ObjectFactory.GetInstance<ICurrentTenantResolver>().Current);
            }
        }
    }
}
