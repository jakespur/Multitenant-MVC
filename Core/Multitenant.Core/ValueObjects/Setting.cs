using System.Collections.Generic;

namespace Multitenant.Core.ValueObjects
{
    public class Setting
    {
        public Setting(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set;}
    }
}
