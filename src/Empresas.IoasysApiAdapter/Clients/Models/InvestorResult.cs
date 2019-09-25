using Newtonsoft.Json;

namespace Empresas.IoasysApiAdapter.Clients.Models
{
    public class InvestorResult
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "investor_name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Balance { get; set; }
        public string Photo { get; set; }
        public PortfolioResult Portfolio { get; set; }
        [JsonProperty(PropertyName = "portfolio_value")]
        public decimal PortifolioValue { get; set; }
        [JsonProperty(PropertyName = "first_access")]
        public bool FistAccess { get; set; }
        [JsonProperty(PropertyName = "super_angel")]
        public bool SuperAngel { get; set; }
    }
}