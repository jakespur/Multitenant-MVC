namespace Multitenant.Repositories
{
    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.ValueObjects;

    public class TenantRepository : ITenantRepository
    {
        public Tenant FindByHostHeader(string hostHeader)
        {
            throw new System.NotImplementedException();
        }
    }
}
