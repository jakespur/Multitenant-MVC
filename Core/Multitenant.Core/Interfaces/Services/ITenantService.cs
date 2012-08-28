using Multitenant.Core.ValueObjects;

namespace Multitenant.Core.Interfaces.Services
{
    public interface ITenantService
    {
        Tenant FindByHostHeader(string hostHeader);
    }
}
