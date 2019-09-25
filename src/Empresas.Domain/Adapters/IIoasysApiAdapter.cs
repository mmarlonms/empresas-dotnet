using Empresas.Domain.Models;
using System.Collections.Generic;

namespace Empresas.Domain.Adapters
{
    public interface IIoasysApiAdapter
    {
        List<Enterprise> ShowAllEnterprises();

        Enterprise ShowEnterpriseByID(int entrepriseId);

        List<Enterprise> ShowEnterpriseByFilter(Dictionary<string, object> filters);

        Investor Authorize(string user, string pass);
    }
}