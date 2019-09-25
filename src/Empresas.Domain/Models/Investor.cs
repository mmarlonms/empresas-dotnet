namespace Empresas.Domain.Models
{
    public class Investor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Balance { get; set; }
        public string Photo { get; set; }
        public Portfolio Portfolio { get; set; }
        public decimal PortifolioValue { get; set; }
        public bool FistAccess { get; set; }
        public bool SuperAngel { get; set; }

        public InvestorAutentication Autentication { get; set; }
    }
}