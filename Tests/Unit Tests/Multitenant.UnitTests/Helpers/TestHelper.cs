using Moq;
using Multitenant.Core.Interfaces.Repositorys;
using Multitenant.Core.ValueObjects;

namespace Multitenant.UnitTests.Helpers
{
    public static class TestHelper
    {
        public static ITenantRepository CreateTenantRepository(string defaultHostHeader, Tenant matchingTenant)
        {
            var repo = new Mock<ITenantRepository>();
            repo.Setup(x => x.FindByHostHeader(defaultHostHeader)).Returns(matchingTenant);
            return repo.Object;
        }
    }
}
