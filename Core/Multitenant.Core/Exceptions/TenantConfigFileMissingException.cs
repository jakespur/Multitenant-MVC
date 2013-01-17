using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multitenant.Core.Exceptions
{
    public class TenantConfigFileMissingException : Exception
    {
        public TenantConfigFileMissingException()
            : base("Tenant Config File Missing")
        {
        }
    }
}
