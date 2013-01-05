namespace Multitenant.Core.Builders
{
    using Multitenant.Core.ValueObjects;

    public static class EnvironmentBuilder
    {
        public static Environment Create(string host)
        {
            return new Environment() { Host = host };
        }
    }
}
