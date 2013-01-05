namespace Multitenant.Core.Exceptions
{
    using System;

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
