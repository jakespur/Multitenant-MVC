using System.Collections.Generic;
using System.Linq;
using Multitenant.Core.Exceptions;
using Multitenant.Core.Interfaces.Services;
using Multitenant.Core.ValueObjects;
using Multitenant.UnitTests.Helpers;
using NUnit.Framework;
using Multitenant.Services;

namespace Multitenant.UnitTests
{
    [TestFixture]
    public class TenantServiceTests
    {
        private ITenantService _service;
        private Tenant _tenant;

        [SetUp]
        public void SetUp()
        {
            const string defaultHostHeader = "acheme1.mvclocal.com";
            _tenant = new Tenant("acheme1", defaultHostHeader);
            _service = new TenantService(TestHelper.CreateTenantRepository(defaultHostHeader, _tenant));
        }

        [Test]
        public void Test_That_I_Can_Bring_Back_The_Correct_Tenant_By_Host_Header()
        {
            //Act
            var actualTenant = _service.FindByHostHeader("acheme1.mvclocal.com");
            //Assert
            Assert.That(actualTenant == _tenant);
        }

        [Test]
        [ExpectedException(typeof(TenantNotFoundException))]
        public void Test_That_If_A_Host_Header_Is_Not_Matched_Custom_Exception_Is_Thrown()
        {
            //Arrange
            const string missingHost = "Idontexist.mvclocal.com";
            //Act
            var missingTenant = _service.FindByHostHeader(missingHost);
        }
    }
}
