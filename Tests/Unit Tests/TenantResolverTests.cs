using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Multitenant.UnitTests
{
    using Multitenant.MvcHelpers;
    using Multitenant.Services;
    using Multitenant.UnitTests.Helpers;

    [TestFixture]
    public class TenantResolverTests
    {
        [Test]
        public void Test_That_I_Can_Get_The_Url_Of_The_Current_Tenent()
        {
            // Arrange
            const string HostHeader = "www.acmedrug.com"; 
            var tenantRepo = TestHelper.MockTenantRepo(HostHeader);
            var resolver = new UrlTenentResolver(HostHeader, new TenantService(tenantRepo));
            // Act
            var actual = resolver.Current;
            // Assert
            Assert.That(actual.Name == "Default");
        }
    }
}
