using AutoMapper;
using Empresas.Domain.Exceptions;
using Empresas.IoasysApiAdapter.Mapper;
using Empresas.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Xunit;

namespace Empresas.Tests.Adapter.Tests
{
    public class IoasysAdapterTests
    {
        readonly ILogger<IoasysApiAdapter.IoasysApiAdapter> loggerMock;
        readonly IHttpContextAccessor httpContextAccessor;

        public IoasysAdapterTests()
        {
            Mapper.Reset();
            Mapper.Initialize(config =>
            {
                config.AddProfile<IoasysAdapterAutoMapperProfiller>();
            });

            loggerMock = LoggerMock.CreateMockLog().Object;
            httpContextAccessor = HttpContextAccessorMocks.CreateHttpContextAccessorMock().Object;
        }

        [Fact]
        public void ShowAllEnterprises_WithoutAnyEnterprises()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithoutAnyEnterprises().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Empty(ioasysApiAdapter.ShowAllEnterprises());
        }

        [Fact]
        public void ShowAllEnterprises_WithOneEnterprise()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithOneEnterprise().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.NotEmpty(ioasysApiAdapter.ShowAllEnterprises());
        }

        [Fact]
        public void ShowEnterpriseByID_WithOneEnterprisesForId()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithOneEnterprisesForId().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Equal("Test", ioasysApiAdapter.ShowEnterpriseByID(1).Name);
        }

        [Fact]
        public void ShowEnterpriseByID_WithoutEnterprisesForId()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithoutEnterprisesForId().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Throws<EnterpriseCoreException>(() => ioasysApiAdapter.ShowEnterpriseByID(1));
        }

        [Fact]
        public void ShowEnterpriseByID_ThrowEnterpriseCoreExceptionForId()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioThrowEnterpriseCoreExceptionForId().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Throws<EnterpriseCoreException>(() => ioasysApiAdapter.ShowEnterpriseByID(1));
        }

        [Fact]
        public void ShowEnterpriseByFilter_WithoutEnterprisesForFilter()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithoutEnterprisesForFilter().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Empty(ioasysApiAdapter.ShowEnterpriseByFilter(new Dictionary<string, object>()));
        }

        [Fact]
        public void ShowEnterpriseByFilter_WithOneEnterprisesForFilter()
        {

            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithOneEnterprisesForFilter().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.NotEmpty(ioasysApiAdapter.ShowEnterpriseByFilter(new Dictionary<string, object>()));
        }

        [Fact]
        public void Authorize_WithInvestorUnauthorized()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithInvestorUnauthorized().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Throws<UnauthorizedAccessException>(() => ioasysApiAdapter.Authorize("User", "Pass"));
        }

        [Fact]
        public void Authorize_WithInvestorSuccessFalse()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithInvestorSuccessFalse().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Throws<InvestorCoreException>(() => ioasysApiAdapter.Authorize("User", "Pass"));

        }

        [Fact]
        public void Authorize_InvestorSuccessTrue()
        {
            var ioasysApiClient = IoasysApiAdapterClientMocks.CreateScenarioWithInvestorSuccessTrue().Object;
            var ioasysApiAdapter = new IoasysApiAdapter.IoasysApiAdapter(httpContextAccessor, ioasysApiClient, loggerMock);

            Assert.Equal("Test", ioasysApiAdapter.Authorize("User", "Pass").Name);
        }
    }
}