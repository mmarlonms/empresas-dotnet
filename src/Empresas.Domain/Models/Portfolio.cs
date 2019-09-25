using System.Collections.Generic;

namespace Empresas.Domain.Models
{
    public class Portfolio
    {
        public int EnterpriseNumber { get; set; }
        public List<Enterprise> Enterprises { get; set; }

        public Portfolio()
        {
            this.Enterprises = new List<Enterprise>();
        }
    }
}