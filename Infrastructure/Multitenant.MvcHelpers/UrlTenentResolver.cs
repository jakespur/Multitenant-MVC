namespace Multitenant.MvcHelpers
{
    using System.Web;

    using Multitenant.Core.Helpers;
    using Multitenant.Core.Interfaces.Resolvers;
    using Multitenant.Core.Interfaces.Services;
    using Multitenant.Core.ValueObjects;

    public class UrlTenentResolver : ICurrentTenantResolver
    {
        public UrlTenentResolver(string hostName, ITenantService service)
        {
            GuardAgainst.Null(service);
            GuardAgainst.Null(hostName);
            var tenant = service.GetByHostHeader(hostName);
            this.Current = tenant;
        }

        public ActiveTenant Current { get; private set; }
    }
}
