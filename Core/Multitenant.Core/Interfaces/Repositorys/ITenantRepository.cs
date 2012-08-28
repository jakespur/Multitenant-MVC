using Multitenant.Core.ValueObjects;

namespace Multitenant.Core.Interfaces.Repositorys
{
    public interface ITenantRepository
    {
        Tenant FindByHostHeader(string hostHeader);
    }
}
