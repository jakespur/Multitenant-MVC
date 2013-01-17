namespace Multitenant.Core.Interfaces.Repositorys
{
    using System.Collections.Generic;

    using Multitenant.Core.ValueObjects;

    public interface ITenantRepository
    {
        Tenant GetByHostHeader(string hostHeader);
        IEnumerable<Tenant> Tenants();
    }
}
