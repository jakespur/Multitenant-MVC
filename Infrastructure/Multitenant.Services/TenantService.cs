using Multitenant.Core.Exceptions;
using Multitenant.Core.Interfaces.Repositorys;
using Multitenant.Core.Interfaces.Services;
using Multitenant.Core.ValueObjects;

namespace Multitenant.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repository;

        public TenantService(ITenantRepository repository)
        {
            _repository = repository;
        }

        public Tenant FindByHostHeader(string hostHeader)
        {
            var tenant = _repository.FindByHostHeader(hostHeader);
            if (tenant == null) throw new TenantNotFoundException(string.Format("Host header : '{0}' failed to resolve to a tenant", hostHeader));
            return tenant;
        }
    }
}
