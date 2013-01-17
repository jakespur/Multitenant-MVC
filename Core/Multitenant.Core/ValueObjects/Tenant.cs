namespace Multitenant.Core.ValueObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using Multitenant.Core.Builders;
    using Multitenant.Core.Interfaces.ValueObjects;

    public class Tenant : ITenant
    {
        public Tenant()
        {
            Environments = new List<HostEnvironment>();
            GlobalSettings = new Dictionary<string, string>();
        }

        public string Name { get; set; }
        public Company Company { get; set; }
        public string ExternalId { get; set; }
        public List<Setting> DefaultSettings { get; set; } 
        public List<HostEnvironment> Environments { get; set; }
        public Dictionary<string, string> GlobalSettings { get; set; }

        public void Add(HostEnvironment environment)
        {
            Environments.Add(environment);
        }

        public HostEnvironment MatchHost(string hostHeader)
        {
            return this.Environments.SingleOrDefault(x => x.HostHeader == hostHeader);
        }

        public static ActiveTenant ReturnActive(string hostHeader, Tenant tenant)
        {
            var matchedHost = tenant.MatchHost(hostHeader);

            return ActiveTenantBuilder.Create(tenant.Name)
                        .WithEnvironment(matchedHost.Type)
                        .WithCompany(tenant.Company)
                        .WithSettings(defaultSettings: tenant.DefaultSettings, hostSettings: matchedHost.Settings);

        }
    }
}
