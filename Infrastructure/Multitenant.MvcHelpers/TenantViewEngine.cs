using System;

namespace Multitenant.MvcHelpers
{
    using System.Web.Mvc;

    using Multitenant.Core.Interfaces.Resolvers;

    public class TenantViewEngine : RazorViewEngine
    {
        private readonly ICurrentTenantResolver _tenant;

        public TenantViewEngine(ICurrentTenantResolver tenant)
        {
            this._tenant = tenant;
            var tenantBaseView = string.Format("~/Tenants/{0}/", this._tenant.Current.Name);
            var tenantViewPath = tenantBaseView + "Views/{1}/{0}";
            var sharedPath = tenantBaseView + "Shared/Views/{0}" ;
            this.ViewLocationFormats = new string[] { tenantViewPath, sharedPath };
            this.PartialViewLocationFormats = new string[] { tenantViewPath, sharedPath };
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
    }
}
