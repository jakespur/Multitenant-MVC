namespace Multitenant.Core.ValueObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using Multitenant.Core.Enums;

    public class ActiveTenant
    {
        public IEnumerable<Setting> Settings { get; private set; }
        public EnvironmentTypeEnum Environment { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }

        public ActiveTenant(IEnumerable<Setting> result)
        {
            Settings = result;
        }
    }
}
