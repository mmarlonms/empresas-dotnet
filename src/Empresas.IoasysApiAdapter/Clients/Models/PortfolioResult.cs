using Newtonsoft.Json;
using System.Collections.Generic;

namespace Empresas.IoasysApiAdapter.Clients.Models
{
    public class PortfolioResult
    {
        [JsonProperty(PropertyName = "enterprises_number")]
        public int EnterpriseNumber { get; set; }
        public List<EnterpriseResult> Enterprises { get; set; }
    }
}