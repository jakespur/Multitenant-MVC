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

        public static ActiveTenant WithExternalId(this ActiveTenant tenant, string externalId)
        {
            tenant.ExternalId = externalId;
            return tenant;
        }

        public static ActiveTenant WithSettings(this ActiveTenant tenant, IEnumerable<Setting> defaultSettings, IEnumerable<Setting> hostSettings)
        {
            var mergedAppSettings = new List<Setting>(); 

            if ((hostSettings != null) && (hostSettings.Any()))
            {
                mergedAppSettings = hostSettings.Concat(defaultSettings).GroupBy(x => x.Key).Select(x => x.First()).ToList();
            }
            else if (defaultSettings != null && defaultSettings.Any())
            {
                mergedAppSettings = defaultSettings.ToList();
            }
            
            tenant.InitializeSettings(mergedAppSettings);
            return tenant;
        }

        public static ActiveTenant WithCompany(this ActiveTenant tenant, Company company)
        {
            tenant.Company = company;
            return tenant;
        }
    }
}
