using Empresas.Domain.Models;
using System.Collections.Generic;

namespace Empresas.Domain.Services
{
    public interface IEmpresasService
    {
        List<Enterprise> ShowAllEnterprises();

        Enterprise ShowEnterpriseByID(int entrepriseId);

        List<Enterprise> ShowEnterpriseByFilter(Dictionary<string,object> filters);
    }
}