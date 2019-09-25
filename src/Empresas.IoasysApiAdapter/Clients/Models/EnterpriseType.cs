using Newtonsoft.Json;

namespace Empresas.IoasysApiAdapter.Clients.Models
{
    public class EnterpriseTypeResult
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "enterprise_type_name")]
        public string Name { get; set; }
    }
}