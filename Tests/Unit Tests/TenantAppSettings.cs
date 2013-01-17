using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multitenant.UnitTests
{
    using System.Configuration;

    using Multitenant.Core.Enums;
    using Multitenant.Core.ValueObjects;
    using Multitenant.Repositories;
    using Multitenant.Services;
    using Multitenant.UnitTests.Helpers;

    using NUnit.Framework;

    [TestFixture]
    public class TenantAppSettings
    {
        private ActiveTenant _tenant;

        [SetUp]
        public void SetUp()
        {
            var repo = new TenantXmlRepository(App.Path + "\\Tenant.Config");
            var service = new TenantService(repo);
            _tenant = service.GetByHostHeader("www.ms121.com");
            Assert.IsNotNull(_tenant, "Tenant should never be null!");
        }

        [Test]
        public void Test_That_I_Can_Read_What_Environment_The_Host_Header_Is_On()
        {
            // Assert
            Assert.That(_tenant.Environment == EnvironmentTypeEnum.Production);
        }

        [Test]
        public void Test_That_Can_Read_The_Default_App_Settings_On_The_Tenent()
        {
            // Assert
            Assert.That(_tenant.Settings["Theme"].Value == "Blue");
        }

        [Test]
        public void Test_That_I_Can_Override_AppSetting_Key_On_A_Specific_Environment()
        {
            // Assert
            Assert.That(_tenant.Settings["LuceneIndexPath"].Value == @"C:\Production\LuceneIndex\ContactCentre");
        }
    }
}
