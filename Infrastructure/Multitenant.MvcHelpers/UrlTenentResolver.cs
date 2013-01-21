namespace Multitenant.MvcHelpers
{
    using System.Web;

    using Multitenant.Core.Helpers;
    using Multitenant.Core.Interfaces.Resolvers;
    using Multitenant.Core.Interfaces.Services;
    using Multitenant.Core.Interfaces.ValueObjects;
    using Multitenant.Core.ValueObjects;

    public class UrlTenentResolver : ICurrentTenantResolver
    {
        private readonly ICurrentHost _host;
        private readonly ITenantService _service;
        private ActiveTenant _activeTenant;

        public UrlTenentResolver(ICurrentHost host, ITenantService service)
        {            
            GuardAgainst.Null(service);
            GuardAgainst.Null(host);
            _host = host;
            _service = service;
        }

        public ActiveTenant Current 
        { 
            get
            {
                return _activeTenant ?? (_activeTenant = _service.GetByHostHeader(_host.Name));
            } 
        }
    }
}
