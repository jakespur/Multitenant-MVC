namespace Multitenant.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Multitenant.Core.Enums;
    using Multitenant.Core.Exceptions;
    using Multitenant.Core.Extensions;
    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.ValueObjects;

    public class TenantXmlRepository : ITenantRepository
    {
        private string _tenantConfigPath;
        private IEnumerable<Tenant> _tenants;
 
        public TenantXmlRepository(string tenantConfigPath)
        {
            if (tenantConfigPath.IsNullOrEmpty()) throw new TenantConfigFileMissingException();
            if (tenantConfigPath.FileNotFound()) throw new TenantConfigFileMissingException();
            this._tenantConfigPath = tenantConfigPath;
            ParseXml();
        }

        public Tenant GetByHostHeader(string hostHeader)
        {
            return _tenants.SingleOrDefault(x => x.Environments.Any(y => y.HostHeader == hostHeader));
        }

        public IEnumerable<Tenant> Tenants()
        {
            return _tenants;
        }

        private void ParseXml()
        {
            var document = XDocument.Load(_tenantConfigPath);
            _tenants = (from tenantDoc in document.Descendants("tenant")
                       select new Tenant()
                           {
                               Name = tenantDoc.Element("name").Value, 
                               Environments = (from env in tenantDoc.Descendants("hostheaders")
                                                   select new HostEnvironment()
                                                       {
                                                          HostHeader = env.Element("host").Attribute("name").Value,
                                                          Type = (EnvironmentTypeEnum)Enum.Parse(typeof(EnvironmentTypeEnum), env.Element("host").Attribute("environment").Value)
                                                       }).ToList()
                           }).ToList();
        }
    }
}
