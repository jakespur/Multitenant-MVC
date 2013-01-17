namespace Multitenant.Core.Builders
{
    using System.Collections.Generic;
    using System.Linq;

    using Multitenant.Core.Enums;
    using Multitenant.Core.ValueObjects;

    public static class ActiveTenantBuilder
    {
        public static ActiveTenant Create(string name)
        {
            return new ActiveTenant() { Name = name };            
        }

        public static ActiveTenant WithEnvironment(this ActiveTenant tenant, EnvironmentTypeEnum type)
        {
            tenant.Environment = type;
            return tenant;
        }

        public static ActiveTenant WithSettings(this ActiveTenant tenant, IEnumerable<Setting> defaultSettings, IEnumerable<Setting> hostSettings)
        {
            var result = hostSettings.Concat(defaultSettings).GroupBy(x => x.Key).Select(x => x.First());
            tenant.SetSettings(result);
            return tenant;
        }

        public static ActiveTenant WithCompany(this ActiveTenant tenant, Company company)
        {
            tenant.Company = company;
            return tenant;
        }
    }
}
