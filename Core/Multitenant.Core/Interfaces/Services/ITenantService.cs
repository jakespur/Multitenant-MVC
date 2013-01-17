namespace Multitenant.Core.Interfaces.Services
{
    using System.Collections.Generic;

    using Multitenant.Core.ValueObjects;

    public interface ITenantService
    {
        ActiveTenant GetByHostHeader(string hostHeader);
        IEnumerable<Tenant> AllTenants();
    }
}