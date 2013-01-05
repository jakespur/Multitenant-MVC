namespace Multitenant.Core.ValueObjects
{
    using Multitenant.Core.Enums;

    public class Environment
    {
        public Environment()
        {
            Type = EnvironmentType.Development;   
        }

        public string Host { get; set; }
        public EnvironmentType Type { get; set; }
    }
}
