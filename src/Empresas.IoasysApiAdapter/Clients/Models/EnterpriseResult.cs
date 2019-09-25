using Newtonsoft.Json;

namespace Empresas.IoasysApiAdapter.Clients.Models
{
    public class EnterpriseResult
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "enterprise_name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "email_enterprise")]
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin  { get; set; }
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "own_enterprise")]
        public bool Own { get; set; }
        public string Photo { get; set; }
        public decimal value { get; set; }
        public int Shares { get; set; }
        [JsonProperty(PropertyName = "share_price")]
        public decimal SharePrice { get; set; }
        [JsonProperty(PropertyName = "own_shares")]
        public int OwnShares { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [JsonProperty(PropertyName = "enterprise_type")]
        public EnterpriseTypeResult EnterpriseType { get; set; }
    }
}