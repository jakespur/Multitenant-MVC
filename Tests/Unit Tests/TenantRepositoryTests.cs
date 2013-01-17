namespace Multitenant.UnitTests
{
    using Multitenant.Core.Builders;
    using System.Linq;

    using Multitenant.Core.Exceptions;
    using Multitenant.Repositories;
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

        [Test]
        [ExpectedException(typeof(TenantConfigFileMissingException))]
        public void Test_That_If_The_Xml_Path_Is_Null_Exception_Occurs()
        {
            // Act
            var repo = new TenantXmlRepository(null);
        }

        [Test]
        [ExpectedException(typeof(TenantConfigFileMissingException))]
        public void Test_That_If_Path_To_Xml_File_Is_Invalid_Exception_Occurs()
        {
            // Act
            var repo = new TenantXmlRepository("TenantMissing.config");
        }

        [Test]
        public void Test_That_I_Can_Read_All_Tenants_From_Xml_Config_File()
        {
            // Arrange
            var tenantConfigFile = string.Concat(App.Path, "\\", "Tenant.config");

            // Act
            var repo = new TenantXmlRepository(tenantConfigFile);

            // Assert
            Assert.That(repo.Tenants().Count() == 2);
        }

        [Test]
        public void Test_That_Can_I_Can_Locate_ACME_1_By_A_Host_Header()
        {
            // Arrange
            var tenantConfigFile = string.Concat(App.Path, "\\", "Tenant.config");
            const string HostHeader = "achme1.local.com";
            
            // Act
            var repo = new TenantXmlRepository(tenantConfigFile);
            var actualTenant = repo.GetByHostHeader(HostHeader);
            
            // Assert
            Assert.IsNotNull(actualTenant);
        }

        [Test]
        public void Test_That_Association_To_Host_Headers_Comes_Back()
        {
            // Arrange
            var tenantConfigFile = string.Concat(App.Path, "\\", "Tenant.config");
            const string HostHeader = "achme1.local.com";
            
            // Act
            var repo = new TenantXmlRepository(tenantConfigFile);
            var actualTenant = repo.GetByHostHeader(HostHeader);
            
            // Assert
            Assert.That(actualTenant.Environments.Count > 1);
        }

        [Test]
        public void Test_That_Association_To_DefaultSettings_Comes_Back()
        {
            // Arrange
            var tenantConfigFile = string.Concat(App.Path, "\\", "Tenant.config");
            const string HostHeader = "achme1.local.com";
            
            // Act
            var repo = new TenantXmlRepository(tenantConfigFile);
            var actualTenant = repo.GetByHostHeader(HostHeader);
            
            // Assert
            Assert.That(actualTenant.DefaultSettings.Count == 2, string.Format("Actual Count : {0}", actualTenant.DefaultSettings));
        }
    }
}
