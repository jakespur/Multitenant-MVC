namespace Multitenant.Core.Builders
{
    using Multitenant.Core.ValueObjects;

    public static class TenantBuilder
    {
        public static Tenant Create(string name)
        {
            return new Tenant()
                {
                    Name = name
                };
        }

        public static Tenant WithHost(this Tenant tenant, HostEnvironment environment)
        {
            tenant.Add(environment);
            return tenant;
        }
    }
}
