namespace Multitenant.Core.ValueObjects
{
    using System.Collections.Generic;

    using Multitenant.Core.Enums;

    public class HostEnvironment
    {
        public HostEnvironment()
        {
            Type = EnvironmentTypeEnum.Development;   
        }

        public string HostHeader { get; set; }
        public EnvironmentTypeEnum Type { get; set; }
        public List<Setting> Settings { get; set; } 
    }
}
