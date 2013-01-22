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
        const string RazorPrefix = ".cshtml";
        const string TenantRoot = "~/Tenants/";
        const string TenantBaseView = TenantRoot + "{TenantName}/";
        const string TenantBaseViewPath = TenantBaseView + "Views/{Controller}/{View}" + RazorPrefix;
        const string TenantBasePartialPath = TenantBaseView + "Views/Shared/{View}" + RazorPrefix;
        const string SharedViewPath = TenantRoot + "Shared/Views/{View}" + RazorPrefix;
        const string SharedViewPartialPath = TenantRoot + "Shared/Views/Shared/{View}" + RazorPrefix;
        
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var controllerName = controllerContext.RouteData.Values["controller"] as string;
            var viewPath = string.Empty;

            if (HasTenantView(controllerName, viewName, out viewPath))
            {
                return base.FindView(controllerContext, viewPath, masterName, useCache);
            }

            if (HasSharedViewPath(controllerName, viewName, out viewPath))
            {
                return base.FindView(controllerContext, viewPath, masterName, useCache);
            }

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            var controllerName = controllerContext.RouteData.Values["controller"] as string;
            var viewPath = string.Empty;

            if (HasTenantPartialView(controllerName, partialViewName, out viewPath))
            {
                return base.FindPartialView(controllerContext, viewPath, useCache);
            }

            if (HasSharedPartialView(controllerName, partialViewName, out viewPath))
            {
                return base.FindPartialView(controllerContext, viewPath, useCache);
            }

            return base.FindPartialView(controllerContext, partialViewName, useCache);
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
            var match = this.HasTenantView(controller, viewName, out viewPath);
            if (match) return true;
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
