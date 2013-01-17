using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multitenant.Core.ValueObjects
{
    public class SettingCollection : List<Setting>
    {
        public Setting this[string key]
        {
            get
            {
                return this.SingleOrDefault(x => x.Key == key);
            }
        }
    }
}
