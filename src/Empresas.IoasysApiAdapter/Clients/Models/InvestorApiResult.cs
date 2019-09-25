namespace Empresas.IoasysApiAdapter.Clients.Models
{
    public class InvestorApiResult
    {
        public InvestorResult Investor { get; set; }
        public EnterpriseResult Enterprise { get; set; }
        public bool Success { get; set; }
    }
}