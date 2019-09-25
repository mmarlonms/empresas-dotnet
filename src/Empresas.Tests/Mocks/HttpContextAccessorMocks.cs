using Microsoft.AspNetCore.Http;
using Moq;

namespace Empresas.Tests.Mocks
{
    public static class HttpContextAccessorMocks
    {
        public static Mock<IHttpContextAccessor> CreateHttpContextAccessorMock()
        {
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            return httpContextAccessorMock;
        }
    }
}