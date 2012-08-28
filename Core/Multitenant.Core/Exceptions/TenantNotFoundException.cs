using System;

namespace Multitenant.Core.Exceptions
{
    public class TenantNotFoundException : Exception
    {
        public TenantNotFoundException() : this("Tenant Not Found")
        {
        }

        public TenantNotFoundException(string message) : base(message)
        {
        }
    }
}
