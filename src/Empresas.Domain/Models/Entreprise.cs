namespace Empresas.Domain.Models
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string Phone { get; set; }
        public bool Own { get; set; }
        public string Photo { get; set; }
        public decimal Value { get; set; }
        public int Shares { get; set; }
        public decimal SharePrice { get; set; }
        public int OwnShares { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public EnterpriseType EnterpriseType { get; set; }
    }
}