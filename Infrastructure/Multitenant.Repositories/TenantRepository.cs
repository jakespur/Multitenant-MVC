using Multitenant.Core.Interfaces.Repositorys;
using Multitenant.Core.ValueObjects;

namespace Multitenant.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        public Tenant FindByHostHeader(string hostHeader)
        {
            throw new System.NotImplementedException();
        }
    }
}
