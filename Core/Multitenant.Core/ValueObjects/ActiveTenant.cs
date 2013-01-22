namespace Multitenant.Core.ValueObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using Multitenant.Core.Enums;

    public class ActiveTenant
    {
        private SettingCollection _settings;
        public SettingCollection Settings 
        { 
            get 
            {
                return _settings;
            }
        }

        public EnvironmentTypeEnum Environment { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public string ExternalId { get; set; }

        public void InitializeSettings(List<Setting> result)
        {
            _settings = new SettingCollection();
            _settings.AddRange(result);
        }
    }
}
