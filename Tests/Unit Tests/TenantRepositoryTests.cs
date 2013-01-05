namespace Multitenant.UnitTests
{
    using Multitenant.Core.Builders;
    using Multitenant.UnitTests.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class TenantRepositoryTests
    {
        [Test]
        public void Test_That_I_Can_Get_A_Tenant()
        {
            // Arrange
            const string HostHeader = "acme.dev.local.com";
            var environment = EnvironmentBuilder.Create(HostHeader);
            var expectedTenant = TenantBuilder.Create("ACME 1").WithHost(environment);
            var repo = TestHelper.MockTenantRepo(HostHeader, expectedTenant);
            
            // Act
            var actualTenant = repo.GetByHostHeader(HostHeader);
            
            // Assert
            Assert.IsNotNull(actualTenant);
        }
    }
}
