using Microsoft.Extensions.Logging;
using Moq;

namespace Empresas.Tests.Mocks
{
    public static class LoggerMock
    {
        public static Mock<ILogger<IoasysApiAdapter.IoasysApiAdapter>> CreateMockLog()
        {
            var mock = new Mock<ILogger<IoasysApiAdapter.IoasysApiAdapter>>();
            return mock;
        }
    }
}