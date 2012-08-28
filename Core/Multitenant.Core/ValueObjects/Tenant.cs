using System;
using System.Collections.Generic;
using Multitenant.Core.Enums;

namespace Multitenant.Core.ValueObjects
{
    public class Tenant
    {
        public Tenant()
        {
            Environments = new List<HostEnvironment>();
            GlobalSettings = new Dictionary<string, string>();
        }

        public Tenant(string tenantName, string hostHeaderAddress) : this()
        {
            Name = tenantName;
            Environments.Add(new HostEnvironment(hostHeaderAddress));
        }

        public string Name { get; set; }
        public List<HostEnvironment> Environments { get; set; }
        public Dictionary<string, string> GlobalSettings { get; set; }
    }

    public class HostEnvironment
    {
        public HostEnvironment()
        {
            Environment = EnvironmentFlag.Development;
            Settings = new Dictionary<string, string>();
        }

        public HostEnvironment(string hostHeader) : this()
        {
            Url = hostHeader;
        }

        public string Url { get; set; }
        public EnvironmentFlag Environment { get; set; }
        private Dictionary<string, string> Settings { get; set; }
    }   
}
