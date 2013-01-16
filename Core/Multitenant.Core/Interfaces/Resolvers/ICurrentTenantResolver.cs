namespace Multitenant.Core.Interfaces.Resolvers
{
    using Multitenant.Core.ValueObjects;

    public interface ICurrentTenantResolver
    {
        Tenant Current { get; }
    }
}
