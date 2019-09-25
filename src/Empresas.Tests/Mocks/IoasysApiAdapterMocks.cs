using Empresas.IoasysApiAdapter.Clients;
using Empresas.IoasysApiAdapter.Clients.Models;
using Moq;
using Newtonsoft.Json;
using Refit;
using System.Collections.Generic;
using System.Net.Http;

namespace Empresas.Tests.Mocks
{
    public static class IoasysApiAdapterClientMocks
    {
        //Enterprises

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithoutAnyEnterprises()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.ShowAllEnterprises(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync(new EnterprisesApiResult());

            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithOneEnterprise()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.ShowAllEnterprises(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync(CreateEnterprisesApiResultBase());

            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithOneEnterprisesForId()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.ShowEnterpriseById(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(CreateEnterpriseApiResultBase(true));

            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithoutEnterprisesForId()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.ShowEnterpriseById(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(CreateEnterpriseApiResultBase(false));

            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioThrowEnterpriseCoreExceptionForId()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.ShowEnterpriseById(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Throws(ApiException.Create(new System.Net.Http.HttpRequestMessage(), new System.Net.Http.HttpMethod("GET"), new System.Net.Http.HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NotFound }, null).Result);
            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithoutEnterprisesForFilter()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.ShowEnterpriseByFilter(It.IsAny<Dictionary<string, object>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new EnterprisesApiResult());

            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithOneEnterprisesForFilter()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.ShowEnterpriseByFilter(It.IsAny<Dictionary<string, object>>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(CreateEnterprisesApiResultBase());

            return mockIoasysAdapter;
        }

        //Investor

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithInvestorUnauthorized()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.Authorize(It.IsAny<object>()))
                .ReturnsAsync(new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized });

            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithInvestorSuccessFalse()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.Authorize(It.IsAny<object>()))
                .ReturnsAsync(new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK , Content = new StringContent(JsonConvert.SerializeObject(CreateInvestorApiResultBase(false))) });

            return mockIoasysAdapter;
        }

        public static Mock<IIoasysApiAdapterClient> CreateScenarioWithInvestorSuccessTrue()
        {
            var mockIoasysAdapter = new Mock<IIoasysApiAdapterClient>();
            mockIoasysAdapter.Setup(x => x.Authorize(It.IsAny<object>()))
                .ReturnsAsync(new HttpResponseMessage() {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(CreateInvestorApiResultBase(true))),
                });

            return mockIoasysAdapter;
        }

        //Aux

        private static EnterprisesApiResult CreateEnterprisesApiResultBase()
        {
            return new EnterprisesApiResult()
            {
                Enterprises = new List<EnterpriseResult>()
                {
                    new EnterpriseResult(){

                        City = "Test",
                        Country = "Test",
                        Description = "Test",
                        Id = 1,
                        Email = "Test",
                        EnterpriseType = new EnterpriseTypeResult()
                        {
                            Id = 1,
                            Name = "Test"
                        },
                        Facebook = "Test",
                        Name = "Test",
                        Linkedin = "Test",
                        Own =false,
                        OwnShares = 0,
                        Phone = "Test",
                        Photo = "Test",
                        SharePrice = 0,
                        Shares = 0,
                        Twitter = "Test",
                        value = 0
                    }
                }
            };
        }

        private static EnterpriseApiResult CreateEnterpriseApiResultBase(bool success)
        {
            return new EnterpriseApiResult()
            {
                Enterprise = new EnterpriseResult()
                {

                    City = "Test",
                    Country = "Test",
                    Description = "Test",
                    Id = 1,
                    Email = "Test",
                    EnterpriseType = new EnterpriseTypeResult()
                    {
                        Id = 1,
                        Name = "Test"
                    },
                    Facebook = "Test",
                    Name = "Test",
                    Linkedin = "Test",
                    Own = false,
                    OwnShares = 0,
                    Phone = "Test",
                    Photo = "Test",
                    SharePrice = 0,
                    Shares = 0,
                    Twitter = "Test",
                    value = 0
                },
                Success = success
            };
        }

        private static InvestorApiResult CreateInvestorApiResultBase(bool success)
        {
            return new InvestorApiResult()
            {
                Investor = new InvestorResult() {
                    Balance = 0,
                    City = "Test",
                    Country = "Test",
                    Email = "Test",
                    FistAccess = false,
                    Id = 1,
                    Name = "Test",
                    Photo = "Test",
                    Portfolio = new PortfolioResult()
                    {
                        EnterpriseNumber = 1,
                        Enterprises = new List<EnterpriseResult>()
                    },
                    PortifolioValue = 0,
                    SuperAngel = false

                },
                Success = success,
                Enterprise = new EnterpriseResult()
            };
        }
    }
}