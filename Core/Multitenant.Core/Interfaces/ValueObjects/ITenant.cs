namespace Multitenant.Core.Interfaces.ValueObjects
{
    using System.Collections.Generic;

    using Multitenant.Core.ValueObjects;

    public interface ITenant
    {
        string Name { get; set; }

        List<Environment> Environments { get; set; }

        Dictionary<string, string> GlobalSettings { get; set; }

        void Add(Environment environment);
    }
}