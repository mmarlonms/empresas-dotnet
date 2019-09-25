using Empresas.Domain.Adapters;
using Empresas.Domain.Models;
using Empresas.Domain.Services;
using System.Collections.Generic;

namespace Empresas.Service
{
    public class EmpresasService : IEmpresasService
    {
        private readonly IIoasysApiAdapter ioasysApiAdapter;

        public EmpresasService(IIoasysApiAdapter ioasysApiAdapter)
        {
            this.ioasysApiAdapter = ioasysApiAdapter;
        }

        public List<Enterprise> ShowAllEnterprises()
        {
            return ioasysApiAdapter.ShowAllEnterprises();
        }

        public List<Enterprise> ShowEnterpriseByFilter(Dictionary<string, object> filters)
        {
            return ioasysApiAdapter.ShowEnterpriseByFilter(filters);
        }

        public Enterprise ShowEnterpriseByID(int entrepriseId)
        {
            return ioasysApiAdapter.ShowEnterpriseByID(entrepriseId);
        }
    }
}