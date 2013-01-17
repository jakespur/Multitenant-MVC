namespace Multitenant.Core.Interfaces.ValueObjects
{
    using System.Collections.Generic;

    using Multitenant.Core.ValueObjects;

    public interface ITenant
    {
        string Name { get; set; }

        List<HostEnvironment> Environments { get; set; }

        Dictionary<string, string> GlobalSettings { get; set; }

        void Add(HostEnvironment environment);
    }
}