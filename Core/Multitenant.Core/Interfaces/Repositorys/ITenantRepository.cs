namespace Multitenant.Core.Interfaces.Repositorys
{
    using Multitenant.Core.ValueObjects;

    public interface ITenantRepository
    {
        Tenant GetByHostHeader(string hostHeader);
    }
}
