namespace Multitenant.UnitTests.Helpers
{
    using Moq;

    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.ValueObjects;

    public static class TestHelper
    {
        public static ITenantRepository MockTenantRepo(string defaultHostHeader, Tenant matchingTenant)
        {
            var repo = new Mock<ITenantRepository>();
            repo.Setup(x => x.GetByHostHeader(defaultHostHeader)).Returns(matchingTenant);
            return repo.Object;
        }
    }
}
