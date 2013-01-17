namespace Multitenant.Core.Builders
{
    using System;

    using Multitenant.Core.ValueObjects;

    public static class HostEnvironmentBuilder
    {
        public static HostEnvironment Create(string host)
        {
            return new HostEnvironment() { HostHeader = host };
        }
    }
}
