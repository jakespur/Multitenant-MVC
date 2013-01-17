using System.Collections.Generic;

namespace Multitenant.Services
{
    using Multitenant.Core.Exceptions;
    using Multitenant.Core.Extensions;
    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.Interfaces.Services;
    using Multitenant.Core.ValueObjects;

    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repository;

        public TenantService(ITenantRepository repository)
        {
            _repository = repository;
        }

        public ActiveTenant GetByHostHeader(string hostHeader)
        {
            var tenant = _repository.GetByHostHeader(hostHeader);
            
            if (tenant.IsNull())
            {
                throw new TenantNotFoundException();
            }

            return Tenant.ReturnActive(hostHeader, tenant);
        }

        public IEnumerable<Tenant> AllTenants()
        {
            return _repository.Tenants();
        }
    }
}
