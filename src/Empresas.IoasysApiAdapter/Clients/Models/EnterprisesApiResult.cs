using System.Collections.Generic;

namespace Empresas.IoasysApiAdapter.Clients.Models
{
    public class EnterprisesApiResult
    {
        public List<EnterpriseResult> Enterprises { get; set; }

        public EnterprisesApiResult()
        {
            this.Enterprises = new List<EnterpriseResult>();
        }
    }
}