namespace Multitenant.MvcHelpers
{
    using System.Web;

    using Multitenant.Core.Exceptions;
    using Multitenant.Core.Helpers;
    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.Interfaces.Resolvers;
    using Multitenant.Core.ValueObjects;

    public class UrlTenentResolver : ICurrentTenantResolver
    {
        public UrlTenentResolver(HttpContextBase httpContext, ITenantRepository repository)
        {
            GuardAgainst.Null(httpContext);
            GuardAgainst.Null(repository);

            var hostName = httpContext.Request.Url.Host;
            var tenant = repository.GetByHostHeader(hostName);
            if (tenant == null) throw new TenantNotFoundException();
            this.Current = tenant;
        }

        public Tenant Current { get; private set; }
    }
}
