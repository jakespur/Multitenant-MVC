namespace Multitenant.UnitTests.Helpers
{
    using System;
    using System.Web;

    using Moq;

    using Multitenant.Core.Builders;
    using Multitenant.Core.Interfaces.Repositorys;
    using Multitenant.Core.ValueObjects;
    
    public enum SecureHttp
    {
        Yes,
        No
    }

    public static class TestHelper
    {
        public static ITenantRepository MockTenantRepo(string defaultHostHeader)
        {
            var repo = new Mock<ITenantRepository>();
            var host = HostEnvironmentBuilder.Create(defaultHostHeader);
            var tenant = TenantBuilder.Create("Default").WithHost(host);
            repo.Setup(x => x.GetByHostHeader(defaultHostHeader)).Returns(tenant);
            return repo.Object;
        }

        public static HttpContextBase MockHttpRequest(string hostName, SecureHttp secured)
        {
            var httpContext = new Mock<HttpContextBase>();
            var mockedRequest = new Mock<HttpRequestBase>();
            var url = (secured == SecureHttp.Yes) ? "https://" : "http://" + hostName;
            var host = new Uri(url);
            mockedRequest.Setup(x => x.Url).Returns(host);
            httpContext.Setup(x => x.Request).Returns(mockedRequest.Object);
            return httpContext.Object;
        }
    }
}
