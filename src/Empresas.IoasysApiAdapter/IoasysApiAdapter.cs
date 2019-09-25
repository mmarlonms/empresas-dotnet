using Empresas.Domain.Adapters;
using Empresas.Domain.Exceptions;
using Empresas.Domain.Models;
using Empresas.IoasysApiAdapter.Clients;
using Empresas.IoasysApiAdapter.Clients.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Empresas.IoasysApiAdapter
{
    public class IoasysApiAdapter : IIoasysApiAdapter
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IIoasysApiAdapterClient ioasysApiAdapterClient;
        private readonly ILogger logger;

        public IoasysApiAdapter(
            IHttpContextAccessor contextAccessor,
            IIoasysApiAdapterClient ioasysApiAdapterClient,
            ILogger<IoasysApiAdapter> logger)
        {
            this.contextAccessor = contextAccessor;
            this.ioasysApiAdapterClient = ioasysApiAdapterClient;
            this.logger = logger;
        }

        public Investor Authorize(string user, string pass)
        {
            var ioasysApiLoginResult = this.ioasysApiAdapterClient.Authorize(new { email = user, password = pass }).Result;

            if (ioasysApiLoginResult.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();

            //Read Body
            Stream ioasysApiLoginResultBodyStream = ioasysApiLoginResult.Content.ReadAsStreamAsync().Result;
            StreamReader readStream = new StreamReader(ioasysApiLoginResultBodyStream, Encoding.UTF8);
            var ioasysApiLoginResultBody = readStream.ReadToEnd();

            var investorApiResult = JsonConvert.DeserializeObject<InvestorApiResult>(ioasysApiLoginResultBody);

            if (!investorApiResult.Success)
                throw new InvestorCoreException(InvestorCoreError.InvestorFailed);

            //Read Headers
            IEnumerable<string> accesTokenValues = new List<string>();
            IEnumerable<string> clientValues = new List<string>();
            IEnumerable<string> uidValues = new List<string>();

            ioasysApiLoginResult?.Headers?.TryGetValues("access-token", out accesTokenValues);
            ioasysApiLoginResult?.Headers?.TryGetValues("client", out clientValues);
            ioasysApiLoginResult?.Headers?.TryGetValues("uid", out uidValues);

            string accesToken = accesTokenValues?.FirstOrDefault();
            string client = clientValues?.FirstOrDefault();
            string uid = uidValues?.FirstOrDefault();

            this.logger.LogInformation("Authorize user{user} with accesToken:{accesToken}, client:{client}, uid:{uid}.", user, accesToken, client, uid);

            var investor = AutoMapper.Mapper.Map<InvestorResult, Investor>(investorApiResult.Investor);
            investor.Autentication = new InvestorAutentication(accesToken, client, uid);

            return investor;
        }

        public List<Enterprise> ShowAllEnterprises()
        {
            string accesToken = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "AccesToken")?.Value;
            string client = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "Client")?.Value; ;
            string uid = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "Uid")?.Value; ;

            this.logger.LogInformation("ShowAllEnterprises, accesToken:{accesToken}, client{client}, uid{uid}.", accesToken, client, uid);

            var result = this.ioasysApiAdapterClient.ShowAllEnterprises(accesToken, client, uid).Result;

            return AutoMapper.Mapper.Map<List<EnterpriseResult>, List<Enterprise>>(result.Enterprises);
        }

        public Enterprise ShowEnterpriseByID(int entrepriseId)
        {
            string accesToken = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "AccesToken")?.Value;
            string client = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "Client")?.Value; ;
            string uid = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "Uid")?.Value; ;

            this.logger.LogInformation("ShowEnterpriseByID, accesToken:{accesToken}, client{client}, uid{uid}.", accesToken, client, uid);

            try
            {
                var result = this.ioasysApiAdapterClient.ShowEnterpriseById(entrepriseId, accesToken, client, uid).Result;

                if (!result.Success)
                    throw new EnterpriseCoreException(EnterpriseCoreError.EnterpriseFailed);

                return AutoMapper.Mapper.Map<EnterpriseResult, Enterprise>(result.Enterprise);

            }
            catch (Exception e) when (e.Message.Contains("404"))
            {
                throw new EnterpriseCoreException(EnterpriseCoreError.EnterpriseNotFound);
            }
        }

        public List<Enterprise> ShowEnterpriseByFilter(Dictionary<string, object> filters)
        {
            string accesToken = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "AccesToken")?.Value;
            string client = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "Client")?.Value; ;
            string uid = contextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "Uid")?.Value; ;

            this.logger.LogInformation("ShowEnterpriseByFilter, accesToken:{accesToken}, client{client}, uid{uid}.", accesToken, client, uid);
            var result = this.ioasysApiAdapterClient.ShowEnterpriseByFilter(filters, accesToken, client, uid).Result;

            return AutoMapper.Mapper.Map<List<EnterpriseResult>, List<Enterprise>>(result.Enterprises);
        }
    }
}