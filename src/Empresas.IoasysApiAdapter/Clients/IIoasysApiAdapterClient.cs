using Empresas.IoasysApiAdapter.Clients.Models;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Empresas.IoasysApiAdapter.Clients
{
    public interface IIoasysApiAdapterClient
    {
        [Get("/v1/enterprises/{enterpriseId}")]
        Task<EnterpriseApiResult> ShowEnterpriseById(int enterpriseId, [Header("access-token")] string AccesToken, [Header("client")] string apiClient, [Header("uid")] string Uid);

        [Get("/v1/enterprises")]
        Task<EnterprisesApiResult> ShowEnterpriseByFilter([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> stuff, [Header("access-token")] string AccesToken, [Header("client")] string apiClient, [Header("uid")] string Uid);

        [Get("/v1/enterprises/")]
        Task<EnterprisesApiResult> ShowAllEnterprises([Header("access-token")] string AccesToken, [Header("client")] string apiClient, [Header("uid")] string Uid);

        [Post("/v1/users/auth/sign_in")]
        [Headers("Content-Type:application/json")]
        Task<HttpResponseMessage> Authorize([Body] object authorizationModel );
    }
}