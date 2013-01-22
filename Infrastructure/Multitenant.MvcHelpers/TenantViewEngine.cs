using System;

namespace Multitenant.MvcHelpers
{
    using System.Web;
    using System.Web.Mvc;

    using Multitenant.Core.Helpers;
    using Multitenant.Core.Interfaces.Resolvers;
    using Multitenant.Core.ValueObjects;

    using StructureMap;

    public class TenantViewEngine : RazorViewEngine
    {
        private ActiveTenant _tenant;
        private const string TenantBaseView = "~/Tenants/{TenantName}/";
        const string TenantBaseViewPath = TenantBaseView + "Views/{Controller}/{View}";
        const string TenantBasePartialPath = TenantBaseView + "Shared/{View}";
        const string SharedViewPath = TenantBaseView + "Shared/Views/{View}";
        const string SharedViewPartialPath = TenantBaseView + "Shared/Views/Shared/{View}";

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (controllerContext.RouteData.Values.ContainsKey("tenant"))
            {
                var controllerName = controllerContext.RouteData.Values["controller"] as string;
                var viewPath = string.Empty;

                if (HasTenantView(controllerName, viewName, out viewPath))
                {
                    return base.FindView(controllerContext, viewPath, masterName, useCache);
                }

                if (HasTenantPartialView(controllerName, viewName, out viewPath))
                {
                    return base.FindView(controllerContext, viewPath, masterName, useCache);
                }

                if (HasSharedViewPath(controllerName, viewName, out viewPath))
                {
                    return base.FindView(controllerContext, viewPath, masterName, useCache);
                }

                if (HasSharedPartialView(controllerName, viewName, out viewPath))
                {
                    return base.FindView(controllerContext, viewPath, masterName, useCache);
                }
            }

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        private bool HasSharedPartialView(string controller, string viewName, out string viewPath)
        {
            viewPath = SharedViewPartialPath.Replace("{Controller}", controller).Replace("{View}", viewName);
            return this.HasView(viewPath);
        }

        private bool HasSharedViewPath(string controller, string viewName, out string viewPath)
        {
            viewPath = SharedViewPath.Replace("{Controller}", controller).Replace("{View}", viewName);
            return this.HasView(viewPath);
        }

        protected bool HasTenantPartialView(string controller, string viewName, out string viewPath)
        {
            viewPath = TenantBasePartialPath.Replace("{TenantName}", TenantName).Replace("{Controller}", controller).Replace("{View}", viewName);
            return this.HasView(viewPath);
        }

        protected bool HasTenantView(string controller, string viewName, out string viewPath)
        {
            viewPath = TenantBaseViewPath.Replace("{TenantName}", TenantName).Replace("{Controller}", controller).Replace("{View}", viewName);
            return this.HasView(viewPath);
        }

        protected string TenantName
        {
            get
            {
                return ActiveTenant.Name;
            }
        }

        protected ActiveTenant ActiveTenant
        {
            get
            {
                return _tenant ?? (_tenant = ObjectFactory.GetInstance<ICurrentTenantResolver>().Current);
            }
        }

        protected HttpRequestBase CurrentRequest
        {
            get
            {
                return ObjectFactory.GetInstance<HttpRequestBase>();
            }
        }

        public bool HasView(string partialViewPath)
        {
            var physicalPath = CurrentRequest.MapPath(partialViewPath);
            return Assert.FileIsValid(physicalPath);
        }
    }
}
