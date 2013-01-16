namespace Multitenant.UnitTests
{
    using Multitenant.Core.Builders;
    using Multitenant.UnitTests.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class TenantRepositoryTests
    {
        [Test]
        public void Test_That_I_Can_Get_A_Tenant_By_The_Host_Name()
        {
            // Arrange
            const string HostHeader = "acme.dev.local.com";
            var repo = TestHelper.MockTenantRepo(HostHeader);
            
            // Act
            var actualTenant = repo.GetByHostHeader(HostHeader);
            
            // Assert
            Assert.IsNotNull(actualTenant);
        }
    }
}
